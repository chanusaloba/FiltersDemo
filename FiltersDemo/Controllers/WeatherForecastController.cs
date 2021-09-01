using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [MySampleAsyncActionFilter("Action")]
        public string Get()
        {
            return "Hello World";
        }
    }

    [TypeFilter(typeof(CustomExceptionFilter))]
    public class FailingController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Testing custom exception filter.");
        }
    }

    [ApiController]
    [Route("[controller]")]
    [MySampleActionFilter("Controller")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [MySampleActionFilter("Action")]
        [MySampleResourceFilter("Action")]
        [TypeFilter(typeof(MySampleResultFilterAttribute), Arguments = new object[] {"Action"})]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
