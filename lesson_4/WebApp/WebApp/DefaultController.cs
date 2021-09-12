using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace WebApp
{
    public class DefaultController : ControllerBase
    {
        private readonly IDistributedCache _cache;

        public DefaultController(IDistributedCache cache)
        {
            _cache = cache;
        }

        [HttpGet("/one")]
        public async Task<IActionResult> One([FromServices] ServiceOne one, [FromQuery] int n = 1)
        {
            var res = await _cache.GetOrAddAsync(n, one.GetCarAsync);

            return Ok(res);
        }

        [HttpGet("/two")]
        public async Task<IActionResult> Two([FromServices] ServiceTwo two, [FromQuery] string key = "foo")
        {
            var res = await _cache.GetOrAddAsync(key, two.GetNameAsync);

            return Ok(res);
        }

        [HttpGet("/three")]
        public async Task<IActionResult> Three([FromServices] ServiceThree three)
        {
            Dude dude = new(1, "Bob");
            await _cache.SetAsync(dude);
            await three.SaveDudeAsync(dude);
            return Ok();
        }
    }
}