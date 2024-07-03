using Data.Models;

namespace Data.Repositories
{
    public interface IWeatherForecastsRepository
    {
        void AddRange(WeatherForecastEntity[] weatherForecastEntities);
    }
}