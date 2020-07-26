using System.Configuration;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Data;
using WeatherApp.Data.Models;
using WeatherApp.Service.Config;
using WeatherApp.WeatherApi;

namespace WeatherApp.Service
{
    public partial class WeatherApiService : ServiceBase
    {
        private readonly CurrentWeatherProvider _apiClient;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public WeatherApiService()
        {
            InitializeComponent();

            _apiClient = new CurrentWeatherProvider();
            _cancellationTokenSource = new CancellationTokenSource();

            EventLog = new EventLog();
            if (!EventLog.SourceExists("WeatherAppService"))
                EventLog.CreateEventSource(
                    "WeatherAppService", "");

            EventLog.Source = "WeatherAppService";
            EventLog.Log = "";
        }

        protected override void OnStart(string[] args)
        {
            //Debugger.Launch();
            new Task(async () =>
            {
                var cities = (LocationConfigurationSection) ConfigurationManager.GetSection("locations");

                foreach (City city in cities.Locations)
                {
                    var response = await _apiClient.GetCurrentWeather(city.Key);
                    EventLog.WriteEntry($"Data received: {response}");

                    var cityReport = new CurrentWeather
                    {
                        City = response.Location.Name,
                        CityName = city.Text,
                        Temperature = response.CurrentWeather.Temperature,
                        Humidity = response.CurrentWeather.Humidity,
                        Pressure = response.CurrentWeather.Pressure,
                        CondText = response.CurrentWeather.Condition.Text,
                        CondIcon = response.CurrentWeather.Condition.Icon,
                        WindDir = response.CurrentWeather.WindDir,
                        WindSpeed = response.CurrentWeather.WindSpeed
                    };

                    await UpdateDb(cityReport);
                }

                Thread.Sleep(60 * 60 * 1000);
            }, _cancellationTokenSource.Token).Start();
        }

        protected override void OnStop()
        {
            _cancellationTokenSource.Cancel();
        }

        private async Task UpdateDb(CurrentWeather report)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.CurrentWeather.AddOrUpdate(report);
                await dataContext.SaveChangesAsync();
            }
        }
    }
}