using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IWeatherForecastsRepository
    {
        void AddRange(WeatherForecastEntity[] weatherForecastEntities);
    }
}