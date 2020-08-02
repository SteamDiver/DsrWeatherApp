using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using LiveCharts;
using LiveCharts.Wpf;
using WeatherApp.Data.Models;
using WeatherApp.GUI.Models;

namespace WeatherApp.GUI.Converters
{
    public class PieChartWeatherDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(ObservableCollection<CurrentWeatherRow>))
            {
                var data = (ObservableCollection<CurrentWeatherRow>) value;
                var seriesCollection = new SeriesCollection();
                IEnumerable<IGrouping<decimal, CurrentWeather>> groups = null;

                switch (parameter)
                {
                    case "Temperature":
                        groups = data.OrderBy(x => x.Weather.Temperature).Select(x => x.Weather)
                            .GroupBy(x => x.Temperature);
                        break;
                    case "Humidity":
                        groups = data.OrderBy(x => x.Weather.Humidity).Select(x => x.Weather).GroupBy(x => x.Humidity);
                        break;
                    case "WindSpeed":
                        groups = data.OrderBy(x => x.Weather.WindSpeed).Select(x => x.Weather)
                            .GroupBy(x => x.WindSpeed);
                        break;
                }

                if (groups != null)
                    foreach (var group in groups)
                        seriesCollection.Add(new PieSeries
                        {
                            Values = new ChartValues<int> {@group.Count()},
                            DataLabels = true,
                            LabelPoint = chartPoint =>
                                $"{chartPoint.Y} ({chartPoint.Participation:P})",
                            Title = @group.Key.ToString(CultureInfo.InvariantCulture)
                        });

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