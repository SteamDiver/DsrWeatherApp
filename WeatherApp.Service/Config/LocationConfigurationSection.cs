using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Service.Config
{
    public class LocationConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("сities")]
        public CityCollection Locations => (CityCollection) base["сities"];
    }
}
