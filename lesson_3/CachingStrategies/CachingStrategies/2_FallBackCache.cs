using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace CachingStrategies
{
    public class FallBackCache : IDistributedCache
    {
        private readonly IDistributedCache _main;
        private readonly IDistributedCache _secondary;

        private int failCount;

        public FallBackCache(IDistributedCache main, IDistributedCache secondary)
        {
            _main = main;
            _secondary = secondary;
        }

        public byte[] Get(string key)
        {
            try
            {
                if (failCount < 3)
                    _main.Get(key);
            }
            catch (Exception e)
            {
                failCount++;
            }

            return _secondary.Get(key);
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