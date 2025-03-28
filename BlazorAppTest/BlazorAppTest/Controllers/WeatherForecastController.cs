using BlazorAppTest.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilling", "Cool", "Mild", "Warm", "Balny", "Hot", "Sweltering",  "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]

        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index =>
            {
                int temperatureC = Random.Shared.Next(-20, 55);
            
                return new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = temperatureC,
                    Summary = Summaries[
                        (temperatureC >= 40) ? 9 :
                        (temperatureC >= 35) ? 8 :
                        (temperatureC >= 30) ? 7 :
                        (temperatureC >= 27) ? 6 :
                        (temperatureC >= 25) ? 5 :
                        (temperatureC >= 18) ? 4 :
                        (temperatureC >= 10) ? 3 :
                        (temperatureC >= 0) ? 2 :
                        (temperatureC >= -10) ? 1 : 0
                    ]
                };
            }).ToArray();
        }
    }
}
