using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WeatherApp.WeatherApi;

namespace WeatherApp.Tests
{
    [TestClass]
    public class WeatherApiTests
    {
        [TestMethod]
        public async Task GetCurrentWeather_Voronezh_ConditionTextNotNull()
        {
            var weatherProvider = new CurrentWeatherProvider();

            var weather = await weatherProvider.GetCurrentWeather("Voronezh");
            var current = weather.CurrentWeather;

            Console.WriteLine(JsonConvert.SerializeObject(weather));
            Assert.IsNotNull(current.Condition.Text);
        }
    }
}
