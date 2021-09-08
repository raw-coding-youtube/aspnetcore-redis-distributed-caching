using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace CachingStrategies
{
    public class WriteBackCache : IDistributedCache
    {
        private readonly IDistributedCache _main;
        private readonly IDistributedCache _secondary;

        public WriteBackCache(IDistributedCache main, IDistributedCache secondary)
        {
            _main = main;
            _secondary = secondary;
            _backgroundTask = Task.Run(WriteBack);
        }

        public byte[] Get(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task<byte[]> GetAsync(string key, CancellationToken token = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        private List<KeyValuePair<string, byte[]>> writeBackBuffer = new();
        private readonly Task _backgroundTask;

        private async Task WriteBack()
        {
            while (true)
            {
                try
                {
                    if (writeBackBuffer.Count > 100)
                    {
                        // build batch update
                    }

                    await Task.Delay(1000 * 60);
                }
                catch (Exception e)
                {

                }
            }
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            _secondary.Set(key, value);
            writeBackBuffer.Add(KeyValuePair.Create(key, value));
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