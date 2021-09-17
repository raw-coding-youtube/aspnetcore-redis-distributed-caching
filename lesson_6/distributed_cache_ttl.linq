<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.Caching.StackExchangeRedis</NuGetReference>
  <NuGetReference>StackExchange.Redis</NuGetReference>
  <Namespace>StackExchange.Redis</Namespace>
  <Namespace>Microsoft.Extensions.Caching.StackExchangeRedis</Namespace>
  <Namespace>Microsoft.Extensions.Options</Namespace>
  <Namespace>Microsoft.Extensions.Caching.Distributed</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

IDistributedCache _cache = new RedisCache(
		Options.Create(new RedisCacheOptions()
		{
			Configuration = "127.0.0.1:6379"
		})
	);

void Main()
{
	//AbsoluteExpiration();

	// SlidingExpiration();
	
	_cache.GetString("key");
}

public void AbsoluteExpiration()
{
	var options = new DistributedCacheEntryOptions()
	{
		AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20)
	};
	
	_cache.SetString("key", "string", options);
}

public void SlidingExpiration()
{
	var options = new DistributedCacheEntryOptions()
	{
		SlidingExpiration = TimeSpan.FromSeconds(30)
	};

	_cache.SetString("key", "string", options);
}