using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using WeatherApp.GUI.Models;

namespace WeatherApp.GUI.Converters
{
    public class BarChartWeatherLabelsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(ObservableCollection<CurrentWeatherRow>))
            {
                var data = (ObservableCollection<CurrentWeatherRow>) value;
                var labels = data
                    .OrderBy(r => r.Weather.Temperature)
                    .GroupBy(r => r.Weather.Temperature)
                    .Select(g => g.Key.ToString(CultureInfo.InvariantCulture)).ToArray();


                return labels;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}