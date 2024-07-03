using Application.Models;

namespace Application.Abstractions
{
    public interface IWeatherForecastsService
    {
        WeatherForecast[] GenerateWeatherForecast();
    }
}