using System.Configuration;

namespace WeatherApp.Service.Config
{
    public class City : ConfigurationElement
    {
        [ConfigurationProperty("key", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Key
        {
            get => (string) base["key"];
            set => base["key"] = value;
        }

        [ConfigurationProperty("text", DefaultValue = "", IsRequired = true)]
        public string Text
        {
            get => (string) base["text"];
            set => base["text"] = value;
        }
    }
}