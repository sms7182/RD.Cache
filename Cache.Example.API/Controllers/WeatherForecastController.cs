using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cache.Example.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICache cache;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,ICache _cache)
        {
            _logger = logger;
            cache = _cache;
        }

        [HttpGet]
        public async Task<object> Get(string key)
        {
           return cache.Get(key);
        }

        [HttpPost]
        public async Task AddToCache(string key,string content)
        {
            cache.Set(key, content);
        }


    }
}
