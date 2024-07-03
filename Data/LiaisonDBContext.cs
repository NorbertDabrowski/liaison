using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{

    public class LiaisonDBContext : DbContext
    {
        //public DbSet<WeatherForecastEntity> WeatherForecast { get; set; }
        public DbSet<WeatherForecastEntity> WeatherForecasts => Set<WeatherForecastEntity>();


        public LiaisonDBContext(DbContextOptions<LiaisonDBContext> options)
            : base(options)
        {
        }
    }
}