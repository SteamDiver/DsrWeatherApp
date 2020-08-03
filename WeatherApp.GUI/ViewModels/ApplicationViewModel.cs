using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using WeatherApp.Data;
using WeatherApp.Data.Models;
using WeatherApp.GUI.Commands;
using WeatherApp.GUI.Helpers;
using WeatherApp.GUI.Models;

namespace WeatherApp.GUI.ViewModels
{
    public class ApplicationViewModel : ViewModel
    {
        public ApplicationViewModel()
        {
            Filter = new Filter();
            RefreshData();
            WeathersView = new CollectionViewSource {Source = Weathers};
            WeathersView.Filter += WeathersViewSourceOnFilter;
        }

        private void WeathersViewSourceOnFilter(object sender, FilterEventArgs e)
        {
            e.Accepted = Filter.GetFilter((CurrentWeatherRow) e.Item);
        }

        public ObservableCollection<CurrentWeatherRow> Weathers { get; private set; }

        public CollectionViewSource WeathersView { get; set; }

        public Filter Filter { get; set; }

        private RelayCommand _filterCommand;

        public RelayCommand FilterCommand
        {
            get
            {
                return _filterCommand ??
                       (_filterCommand = new RelayCommand(obj =>
                       {
                           WeathersView.View.Refresh();
                       }));
            }
        }

        public void RefreshData()
        {
            using (var dataContext = new DataContext())
            {
                var data = dataContext.CurrentWeather.ToList();
                var minTemp = data.Min(w => w.Temperature);
                var maxTemp = data.Max(w => w.Temperature);

                Weathers = new ObservableCollection<CurrentWeatherRow>(data.Select(record =>
                    new CurrentWeatherRow
                    {
                        BackgroundColor = ColorHelper.GetWeatherRowColor(minTemp, maxTemp, record.Temperature),
                        Weather = record
                    }));
            }
        }
    }
}