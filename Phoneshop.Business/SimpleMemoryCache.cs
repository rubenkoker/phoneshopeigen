using Microsoft.Extensions.Caching.Memory;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoneshop.Business
{
    public class SimpleMemoryCache<TItem> : ICaching<TItem>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public async Task<TItem> GetOrCreate(object key, Func<TItem> createItem)
        {
            TItem cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                // Key not in cache, so get data.
                cacheEntry = createItem();

                // Save data in cache.
                _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }
    }
}
