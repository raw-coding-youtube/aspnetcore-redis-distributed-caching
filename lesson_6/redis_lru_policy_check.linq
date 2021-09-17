<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.Caching.StackExchangeRedis</NuGetReference>
  <NuGetReference>StackExchange.Redis</NuGetReference>
  <Namespace>StackExchange.Redis</Namespace>
  <Namespace>Microsoft.Extensions.Caching.StackExchangeRedis</Namespace>
  <Namespace>Microsoft.Extensions.Options</Namespace>
  <Namespace>Microsoft.Extensions.Caching.Distributed</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	IDistributedCache cache = new RedisCache(
		Options.Create(new RedisCacheOptions()
		{
			Configuration = "127.0.0.1:6379"
		})
	);

	var twoMegabytes = (1024 * 1024 * 2);
	var chunks = 10;
	var chunkSize = twoMegabytes / chunks;

	var bigWords = Enumerable.Range(0, chunks + 1).Select(_ => BigA(chunkSize));

	int i = 0;
	foreach (var word in bigWords)
	{
		cache.SetString(i.ToString(), word);
		cache.Get(0.ToString());
		i++;
	}
}

public string BigA(int length)
{
	var builder = new StringBuilder();

	for (int i = 0; i < length; i++)
	{
		builder.Append("a");
	}

	return builder.ToString();
}