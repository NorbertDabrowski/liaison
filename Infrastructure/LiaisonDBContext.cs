using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class LiaisonDBContext : DbContext
    {
        public LiaisonDBContext(DbContextOptions<LiaisonDBContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecastEntity> WeatherForecasts => Set<WeatherForecastEntity>();
    }
}