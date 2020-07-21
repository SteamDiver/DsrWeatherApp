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
        public DataContext() : base("DbConnection")
        {
        }
        public DbSet<CurrentWeather> CurrentWeather { get; set; }
    }
}
