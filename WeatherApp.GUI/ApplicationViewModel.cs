using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WeatherApp.Data;
using WeatherApp.Data.Models;
using WeatherApp.GUI.Annotations;
using WeatherApp.GUI.Models;

namespace WeatherApp.GUI
{
    public class ApplicationViewModel : ViewModel
    {
        public ObservableCollection<CurrentWeatherRow> Weathers { get; private set; }

        public ApplicationViewModel()
        {
            RefreshData();
        }

        public void RefreshData()
        {
            using (var dataContext = new DataContext())
            {
                var weather = dataContext.CurrentWeather.ToList();
                var minTemp = weather.Min(r => r.Temperature);
                var maxTemp = weather.Max(r => r.Temperature);

                Weathers = new ObservableCollection<CurrentWeatherRow>(weather.Select(r=>new CurrentWeatherRow()
                {
                    BackgroundColor = ColorHelper.GetWeatherRowColor(minTemp, maxTemp, r.Temperature), 
                    Weather = r
                }));
            }
        }
    }
}
