using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using LiveCharts;
using LiveCharts.Wpf;
using WeatherApp.GUI.Models;

namespace WeatherApp.GUI.Converters
{
    public class BarChartWeatherDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(ObservableCollection<CurrentWeatherRow>))
            {
                var data = (ObservableCollection<CurrentWeatherRow>) value;
                var seriesCollection = new SeriesCollection();
                var groups = data.OrderBy(r=>r.Weather.Temperature).Select(r => r.Weather).GroupBy(x => x.Temperature);

                foreach (var group in groups)
                {
                    seriesCollection.Add(new ColumnSeries()
                    {
                        Title = group.Key.ToString(),
                        Values = new ChartValues<int>(){group.Count()},
                        DataLabels = true
                    });
                }

                return seriesCollection;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}