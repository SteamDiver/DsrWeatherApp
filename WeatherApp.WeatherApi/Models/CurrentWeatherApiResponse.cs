using Newtonsoft.Json;

namespace WeatherApp.WeatherApi.Models
{
    /// <summary>
    ///     WeatherApi current weather response DTO.
    /// </summary>
    public class CurrentWeatherApiResponse : WeatherApiResponse
    {
        [JsonProperty("current")] public CurrentWeather CurrentWeather { get; set; }
    }
}