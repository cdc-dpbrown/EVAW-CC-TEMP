using System;
    
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace Ewav.Cache
{
    public class EwavCacheSurveyRefreshAction : ICacheItemRefreshAction
    {
        public event EventHandler<EwavCacheSurveyItemEventArgs> EwavCacheSurveyItemExpired;

        public void Refresh(string key, object expiredValue, CacheItemRemovedReason removalReason)
        {
            if (removalReason == CacheItemRemovedReason.Expired)
            {
                this.EwavCacheSurveyItemExpired(this, new EwavCacheSurveyItemEventArgs() { key = key });
            }
        }
    }
}