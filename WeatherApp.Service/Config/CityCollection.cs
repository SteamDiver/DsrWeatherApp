using System.Configuration;

namespace WeatherApp.Service.Config
{
    [ConfigurationCollection(typeof(City))]
    public class CityCollection : ConfigurationElementCollection
    {
        public City this[int idx] => (City) BaseGet(idx);

        protected override ConfigurationElement CreateNewElement()
        {
            return new City();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((City) element).Key;
        }
    }
}