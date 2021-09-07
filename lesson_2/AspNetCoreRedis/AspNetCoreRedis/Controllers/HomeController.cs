using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace AspNetCoreRedis.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index([FromServices] IDistributedCache cache)
        {
            return Ok(cache.GetString("rat"));
        }
    }
}