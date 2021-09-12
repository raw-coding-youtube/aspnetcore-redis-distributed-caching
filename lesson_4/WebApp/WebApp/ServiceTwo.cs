using System.Threading.Tasks;

namespace WebApp
{
    public class ServiceTwo
    {
        public Task<string> GetNameAsync(string id) => Task.FromResult("Bob");
    }
}