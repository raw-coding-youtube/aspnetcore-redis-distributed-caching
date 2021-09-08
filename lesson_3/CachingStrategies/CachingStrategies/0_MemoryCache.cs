using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace CachingStrategies
{
    public class MemoryCache : IDistributedCache
    {
        public byte[] Get(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task<byte[]> GetAsync(string key, CancellationToken token = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            throw new System.NotImplementedException();
        }

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public void Refresh(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task RefreshAsync(string key, CancellationToken token = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(string key, CancellationToken token = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}