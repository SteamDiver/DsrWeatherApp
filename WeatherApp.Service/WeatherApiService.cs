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
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace WeatherApp.Service
{
    public partial class WeatherApiService : ServiceBase
    {
        private readonly CurrentWeatherProvider _apiClient;
        private readonly DataContext _dataContext;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public WeatherApiService()
        {
            InitializeComponent();

            _apiClient = new CurrentWeatherProvider();
            _dataContext = new DataContext();

            _cancellationTokenSource = new CancellationTokenSource();

            EventLog = new EventLog();
            if (!EventLog.SourceExists("WeatherAppService"))
            {
                EventLog.CreateEventSource(
                    "WeatherAppService", "");
            }

            EventLog.Source = "WeatherAppService";
            EventLog.Log = "";
        }

        //TODO Add weather report timestamp to db and dto model
        protected override void OnStart(string[] args)
        {
            Debugger.Launch();
            new Task(async () =>
            {
                var cities = (LocationConfigurationSection) ConfigurationManager.GetSection("locations");

                foreach (City city in cities.Locations)
                {
                    var weather = await _apiClient.GetCurrentWeather(city.Key);
                    EventLog.WriteEntry($"Data received: {weather}");

                    await UpdateDb(weather);
                }

                Thread.Sleep(60 * 60 * 100);
            }, _cancellationTokenSource.Token).Start();
        }

        protected override void OnStop()
        {
            _cancellationTokenSource.Cancel();
        }

        private async Task UpdateDb(CurrentWeatherApiResponse response)
        {
            _dataContext.CurrentWeather.AddOrUpdate(new Data.Models.CurrentWeather()
            {
                City = response.Location.Name,
                Temperature = response.CurrentWeather.Temperature,
                Humidity = response.CurrentWeather.Humidity,
                Pressure = response.CurrentWeather.Pressure,
                CondText = response.CurrentWeather.Condition.Text,
                CondIcon = response.CurrentWeather.Condition.Icon,
                WindDir = response.CurrentWeather.WindDir,
                WindSpeed = response.CurrentWeather.WindSpeed
            });

            await _dataContext.SaveChangesAsync();
        }
    }
}