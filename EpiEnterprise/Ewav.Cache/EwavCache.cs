using System;
using System.Data;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System.Collections;

namespace Ewav.Cache
{




    public class EwavCache
    {
        public static readonly EwavCache Instance = new EwavCache();

        private CacheStats cacheStats;

        private readonly ICacheManager cacheManager;

        private readonly EwavCacheSurveyRefreshAction ewavCacheSurveyRefreshAction = new EwavCacheSurveyRefreshAction();

        public ICacheEnabledDao Dao { get; set; }

        private EwavCache()
        {
            //       if (cacheManager == null)
            this.cacheManager = CacheFactory.GetCacheManager();

            cacheStats = new CacheStats();

            this.ewavCacheSurveyRefreshAction.EwavCacheSurveyItemExpired += new EventHandler<EwavCacheSurveyItemEventArgs>(ewavCacheSurveyRefreshAction_EwavCacheSurveyItemExpired);
        }

        void ewavCacheSurveyRefreshAction_EwavCacheSurveyItemExpired(object sender, EwavCacheSurveyItemEventArgs e)
        {


            DataTable dt = Utilities.Utilities.CreateDT(100, 10000);
            Add(e.key, dt);     

            // update cache stats    
            //  CacheCatalogItem cc = cacheStats.Catalog.Single(k => k == e.key);
            CacheCatalogItem cc = cacheStats.Catalog[e.key];
            cc.Refreshcount++;


        }


        private void UpdateStats()
        {
            cacheStats.Count = cacheManager.Count;
            cacheStats.Catalog.Clear();


            // surprised this is required  
            Microsoft.Practices.EnterpriseLibrary.Caching.Cache myCache = (Microsoft.Practices.EnterpriseLibrary.Caching.Cache)cacheManager.GetType().GetField("realCache", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(cacheManager);

            cacheStats.TotalSize = 0;


            foreach (DictionaryEntry Item in myCache.CurrentCacheState)
            {


                CacheItem cacheItem = (CacheItem)Item.Value;


                string thisKey = Item.Key.ToString();


                if (cacheStats.Catalog.ContainsKey(thisKey) == false)
                {
                    CacheCatalogItem cc = new CacheCatalogItem();

                    cc.LastAccessed = cacheItem.LastAccessedTime;

                    //  Of course this is not the true create datae but it is close enough        
                    cc.Created = cacheItem.LastAccessedTime;

                    cc.Size = Utilities.Utilities.GetSize(cacheItem.Value);
                    cc.Key = thisKey;
                    cc.ExpirationData = getExpirationData(cacheItem);

                    cacheStats.Catalog.Add(thisKey, cc);

                    cacheStats.TotalSize += cc.Size;
                }
                else
                {

                    CacheCatalogItem cc = cacheStats.Catalog[thisKey];

                    cc.Age = (DateTime.Now - cc.Created).Minutes;

                    cc.LastAccessed = cacheItem.LastAccessedTime;

                    cc.Size = Utilities.Utilities.GetSize(cacheItem.Value);
                    cc.Key = thisKey;
                    cc.ExpirationData = getExpirationData(cacheItem);

                    cacheStats.TotalSize += cc.Size;

                }



            }
        }


        /// <summary>
        /// Gets the expiration data.
        /// </summary>
        /// <param name="cacheItem">The cache item.</param>
        private string getExpirationData(CacheItem cacheItem)
        {


            string expData = "";

            ICacheItemExpiration[] exps = cacheItem.GetExpirations();
            for (int ex = 0; ex < exps.Length; ex++)
            {

                if (exps[ex] is AbsoluteTime)
                {

                    AbsoluteTime absoluteTime = (AbsoluteTime)exps[ex];
                    expData += "AbsoluteExpirationTime  = " + absoluteTime.AbsoluteExpirationTime.ToString() + "\n";

                }
                else if (exps[ex] is SlidingTime)
                {

                    SlidingTime slidingTime = (SlidingTime)exps[ex];
                    expData += "SlidingTime = " + slidingTime.ItemSlidingExpiration.TotalMinutes.ToString() +
                         " LastUsed = " + slidingTime.TimeLastUsed.ToString() + "\n";
                }


            }


            return expData;
        }

        public void ForceRefresh(string key, DataTable dt)
        {
            this.cacheManager.Remove(key);
            this.Add(key, dt);
        }

        public CacheStats GetStats()
        {

            UpdateStats();

            return cacheStats;
        }


        public object Get(string key)
        {
            return this.cacheManager.GetData(key);
        }



        public void Add(string key, DataTable dt, int slidingMinutes = 4, int absoluteMinutes = 5)
        {
            SlidingTime slidingTime = new SlidingTime(TimeSpan.FromMinutes(slidingMinutes));
            AbsoluteTime absoluteTime = new AbsoluteTime(TimeSpan.FromMinutes(absoluteMinutes));

            GetStats();


            this.cacheManager.Add(key, dt, CacheItemPriority.Normal, this.ewavCacheSurveyRefreshAction,
                slidingTime, absoluteTime);
        }
    }
}