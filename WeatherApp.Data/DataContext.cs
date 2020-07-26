using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
