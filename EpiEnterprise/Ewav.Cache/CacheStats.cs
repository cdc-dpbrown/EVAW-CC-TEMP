using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ewav.Utilities;


namespace Ewav.Cache
{
    public struct CacheCatalogItem
    {
        public string Key { get; set; }

        public long Size { get; set; }

        public int Expires { get; set; }

        public int Age { get; set; }

        public int Refreshcount { get; set; }

        /// <summary>
        /// Gets or sets the last accessed.
        /// </summary>
        /// <value>The last accessed.</value>
        public DateTime LastAccessed { get; set; }
        /// <summary>
        /// Gets or sets the expiration data.
        /// </summary>
        /// <value>The expiration data.</value>
        public string ExpirationData { get; set; }
        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>The created.</value>
        public DateTime Created { get; set; }
    }

    public class CacheStats
    {
        public int Count { get; set; }

        public Dictionary<string, CacheCatalogItem> Catalog { get; set; }     
        // public List<CacheCatalogItem> Catalog     { get; set; }    

        public long TotalSize { get; set; }

        /// <summary>
        /// Initializes the <see cref="CacheStats" /> class.
        /// </summary>
        public CacheStats()
        {


            Catalog = new Dictionary<string, CacheCatalogItem>();        



        }
    }
}
