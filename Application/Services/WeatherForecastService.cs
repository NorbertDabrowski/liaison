using Application.Abstractions;
using Application.Models;
using Domain.Abstractions;

namespace Application.Services
{
    public class WeatherForecastService : IWeatherForecastsService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IWeatherForecastsRepository _weatherForecastsRepository;

        public WeatherForecastService(IWeatherForecastsRepository weatherForecastsRepository)
        {
            _weatherForecastsRepository = weatherForecastsRepository;
        }

        public WeatherForecast[] GenerateWeatherForecast()
        {
            var weatherForecastArray = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();

            _weatherForecastsRepository.AddRange(
               weatherForecastArray.Select(x => new Domain.Entities.WeatherForecastEntity
               {
                   Date = x.Date.ToDateTime(TimeOnly.MinValue),
                   TemperatureC = x.TemperatureC,
                   Summary = x.Summary,
               }).ToArray());

            return weatherForecastArray;
        }
    }
}
