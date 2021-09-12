using System.Threading.Tasks;

namespace WebApp
{
    public class ServiceThree
    {
        public Task SaveDudeAsync(Dude dude) => Task.CompletedTask;
    }

    public record Dude(int Id, string Name, bool Cool = true) : ICacheKey
    {
        public string CacheKey => $"dude_{Id}";
    }

    public interface ICacheKey
    {
        string CacheKey { get; }
    }
}