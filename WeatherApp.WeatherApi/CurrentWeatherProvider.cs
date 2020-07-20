using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.WeatherApi.Models;

namespace WeatherApp.WeatherApi
{
    /// <summary>
    /// Current weather data provider
    /// </summary>
    public class CurrentWeatherProvider : WeatherProvider
    {
        public CurrentWeatherProvider() : base("current.json")
        {

        }

        /// <summary>
        /// Performs current weather request for specified location
        /// </summary>
        /// <param name="cityName">city</param>
        /// <returns>Current weather info</returns>
        public async Task<CurrentWeatherApiResponse> GetCurrentWeather(string cityName)
        {
            var jsonString = await DoGet(cityName);
            if (jsonString != null)
            {
                return JsonConvert.DeserializeObject<CurrentWeatherApiResponse>(jsonString);
            }

            return null;
        }
    }
}
