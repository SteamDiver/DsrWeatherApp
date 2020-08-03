using System.Collections.ObjectModel;
using System.Linq;
using WeatherApp.Data;
using WeatherApp.GUI.Helpers;
using WeatherApp.GUI.Models;

namespace WeatherApp.GUI.ViewModels
{
    public class ApplicationViewModel : ViewModel
    {
        public ApplicationViewModel()
        {
            RefreshData();
        }

        public ObservableCollection<CurrentWeatherRow> Weathers { get; private set; }

        public void RefreshData()
        {
            using (var dataContext = new DataContext())
            {
                var weather = dataContext.CurrentWeather.ToList();
                if (weather?.Count > 0)
                {
                    var minTemp = weather.Min(w => w.Temperature);
                    var maxTemp = weather.Max(w => w.Temperature);

                    Weathers = new ObservableCollection<CurrentWeatherRow>(weather.Select(record => new CurrentWeatherRow
                    {
                        BackgroundColor = ColorHelper.GetWeatherRowColor(minTemp, maxTemp, record.Temperature),
                        Weather = record
                    }));
                }
            }
        }
    }
}