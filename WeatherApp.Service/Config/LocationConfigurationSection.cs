using System.Configuration;

namespace WeatherApp.Service.Config
{
    public class LocationConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("сities")] public CityCollection Locations => (CityCollection) base["сities"];
    }
}