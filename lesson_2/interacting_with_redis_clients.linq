<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.Caching.StackExchangeRedis</NuGetReference>
  <NuGetReference>StackExchange.Redis</NuGetReference>
  <Namespace>StackExchange.Redis</Namespace>
  <Namespace>Microsoft.Extensions.Caching.StackExchangeRedis</Namespace>
  <Namespace>Microsoft.Extensions.Options</Namespace>
  <Namespace>Microsoft.Extensions.Caching.Distributed</Namespace>
</Query>

void Main()
{
	//ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1");
	//
	//IDatabase db = redis.GetDatabase();
	//
	//db.StringGet("dog").Dump();
	//db.StringGet("cat").Dump();


	var options = Options.Create(new RedisCacheOptions()
	{
		Configuration = "127.0.0.1:6379"
	});
	IDistributedCache cache = new RedisCache(options);
	
	//cache.SetString("rat", "bob");
	cache.GetString("rat").Dump();
	
}

