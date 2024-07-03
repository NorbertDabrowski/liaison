using Application.Abstractions;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastsService _weatherForecastsService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         IWeatherForecastsService weatherForecastsService)
        {
            _logger = logger;
            _weatherForecastsService = weatherForecastsService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastsService.GenerateWeatherForecast();
        }
    }
}
