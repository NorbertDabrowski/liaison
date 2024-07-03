using Data.Models;

namespace Data.Repositories
{
    public class WeatherForecastsRepository : IWeatherForecastsRepository
    {
        private readonly LiaisonDBContext _dbContext;
        public WeatherForecastsRepository(LiaisonDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRange(WeatherForecastEntity[] weatherForecastEntities)
        {
            ArgumentNullException.ThrowIfNull(weatherForecastEntities);

            _dbContext.WeatherForecasts.AddRange(weatherForecastEntities);
            _dbContext.SaveChanges();
        }
    }

}