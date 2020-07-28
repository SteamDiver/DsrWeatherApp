using System.Windows.Media;
using WeatherApp.Data.Models;

namespace WeatherApp.GUI.Models
{
    public class CurrentWeatherRow
    {
        public SolidColorBrush BackgroundColor { get; set; }
        public CurrentWeather Weather { get; set; }
    }
}