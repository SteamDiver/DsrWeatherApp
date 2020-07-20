using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.Web.UI.WebControls;
using WeatherApp.Data;
using WeatherApp.Service.Config;
using WeatherApp.WeatherApi;
using WeatherApp.WeatherApi.Models;

namespace WeatherApp.Service
{
    public partial class WeatherApiService : ServiceBase
    {
        private CurrentWeatherProvider _apiClient;
        private DataContext _dataContext; 
        private CancellationTokenSource _cancellationTokenSource;

        public WeatherApiService()
        {
            InitializeComponent();

            _apiClient = new CurrentWeatherProvider();
            _dataContext = new DataContext();

            _cancellationTokenSource = new CancellationTokenSource();
        }

        protected override void OnStart(string[] args)
        {
            System.Diagnostics.Debugger.Launch(); 
            new Task(async () =>
            {
                var cities = (CityCollection)ConfigurationManager.GetSection("locations");
                var weatherConditions = new List<CurrentWeatherApiResponse>();
                foreach (City city in cities)
                {
                    var weather = await _apiClient.GetCurrentWeather(city.Key);
                }
                Thread.Sleep(60 * 60 * 100);
            }, _cancellationTokenSource.Token).Start();
        }

        protected override void OnStop()
        {
            CancellationTokenSource.CreateLinkedTokenSource().Cancel();
        }
    }
}
