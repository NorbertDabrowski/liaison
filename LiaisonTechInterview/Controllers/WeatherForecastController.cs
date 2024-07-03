using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LiaisonTechInterview.Controllers
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
        private readonly IWeatherForecastsRepository _weatherForecastsRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         IWeatherForecastsRepository weatherForecastsRepository)
        {
            _logger = logger;
            _weatherForecastsRepository = weatherForecastsRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var weatherForecastArray = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            _weatherForecastsRepository.AddRange(
                weatherForecastArray.Select(x => new Data.Models.WeatherForecastEntity
                {
                    Date = x.Date.ToDateTime(TimeOnly.MinValue),
                    TemperatureC = x.TemperatureC,
                    Summary = x.Summary,
                }).ToArray());

            return weatherForecastArray;
        }
    }
}
