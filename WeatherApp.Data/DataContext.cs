using System.Data.Entity;
using WeatherApp.Data.Models;

namespace WeatherApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(@"Data Source=localhost;Initial Catalog=WeatherAppDb;Integrated Security=True")
        {
        }

        public virtual DbSet<CurrentWeather> CurrentWeather { get; set; }
    }
}