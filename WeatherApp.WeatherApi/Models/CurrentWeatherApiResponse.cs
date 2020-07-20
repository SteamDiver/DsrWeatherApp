using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.WeatherApi.Models
{
    /// <summary>
    /// WeatherApi current weather response DTO.
    /// </summary>
    public class CurrentWeatherApiResponse : WeatherApiResponse
    {
        [JsonProperty("current")]
        public CurrentWeather CurrentWeather { get; set; }
    }
}
