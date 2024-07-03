using Domain.Primitives;

namespace Domain.Entities
{
    public class WeatherForecastEntity : Entity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }
}
