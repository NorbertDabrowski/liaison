
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LiaisonTechInterview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<LiaisonDBContext>(opt => opt.UseSqlServer(connectionString));
            //builder.Services.AddDbContext<LiaisonDBContext>(opt => opt.UseInMemoryDatabase("LiaisonTechInterview"));

            builder.Services.AddScoped<IWeatherForecastsRepository, WeatherForecastsRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            using var scope = app.Services.CreateScope();
            var database = scope.ServiceProvider.GetRequiredService<LiaisonDBContext>().Database;
            database.EnsureCreated();

            app.Run();
        }
    }
}
