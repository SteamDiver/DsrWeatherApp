using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Service.Config
{
    [ConfigurationCollection(typeof(City))]
    public class CityCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new City();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((City)(element)).Key;
        }
        public City this[int idx] => (City)BaseGet(idx);
    }
}
