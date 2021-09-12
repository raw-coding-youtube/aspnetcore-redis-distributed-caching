using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace WebApp
{
    public static class IDistributedCacheExtensions
    {
        public static async Task<GetCachedValue<T>> GetOrAddAsync<T, TKey>(
            this IDistributedCache cache,
            TKey anyKey,
            Func<TKey, Task<T>> factory
        )
            where T : class
        {
            var key = anyKey switch
            {
                string k => k,
                _ => anyKey.ToString(),
            };

            var value = await cache.GetAsync<T>(key);
            if (value == null)
            {
                value = await factory(anyKey);
                await cache.SetStringAsync(key, JsonSerializer.Serialize(value));
                return new(false, value);
            }

            return new(true, value);
        }

        public static async Task<T> GetAsync<T>(this IDistributedCache cache, string key)
            where T : class
        {
            var jsonValue = await cache.GetStringAsync(key);
            if (string.IsNullOrEmpty(jsonValue))
            {
                return null;
            }

            return JsonSerializer.Deserialize<T>(jsonValue);
        }

        public static async Task<long> GetLongAsync(this IDistributedCache cache, string key)
        {
            var value = await cache.GetAsync(key);
            return BitConverter.ToInt64(value);
        }

        public static Task SetLongAsync(this IDistributedCache cache, string key, long value)
        {
            return cache.SetAsync(key, BitConverter.GetBytes(value));
        }

        public static async Task<DateTime> GetDateTimeAsync(this IDistributedCache cache, string key)
        {
            var value = await cache.GetAsync(key);
            var ticks = BitConverter.ToInt64(value);
            return new(ticks);
        }

        public static Task SetDateTimeAsync(this IDistributedCache cache, string key, DateTime value)
        {
            var ticks = value.Ticks;
            return cache.SetAsync(key, BitConverter.GetBytes(ticks));
        }

        public static Task SetAsync<T>(this IDistributedCache cache, T value)
            where T : ICacheKey
        {
            return cache.SetStringAsync(value.CacheKey, JsonSerializer.Serialize(value));
        }

        public record GetCachedValue<T>(bool Cached, T value);
    }
}