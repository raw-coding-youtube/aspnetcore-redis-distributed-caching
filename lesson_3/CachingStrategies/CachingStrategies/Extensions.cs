using Microsoft.Extensions.Caching.Distributed;

namespace CachingStrategies
{
    public static class Extensions
    {
        public static IDistributedCache ToNamespaced(this IDistributedCache @this, string name) =>
            new NamespacedCache(@this, name);
    }
}