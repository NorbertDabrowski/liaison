using Application.Abstractions;
using Application.Services;
using Domain.Abstractions;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
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
            builder.Services.AddScoped<IWeatherForecastsService, WeatherForecastService>();

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
