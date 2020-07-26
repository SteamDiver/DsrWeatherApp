using Newtonsoft.Json;

namespace WeatherApp.WeatherApi.Models
{
    /// <summary>
    ///     WeatherAPI location DTO.
    ///     Location object is returned with each API response
    ///     https://www.weatherapi.com/docs/
    /// </summary>
    public class Location
    {
        /// <summary>
        ///     Location name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Region or state of the location, if availa
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        ///     Location country
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        ///     Latitude in decimal degree
        /// </summary>
        [JsonProperty("lat")]
        public decimal Lat { get; set; }

        /// <summary>
        ///     Longitude in decimal degree
        /// </summary>
        [JsonProperty("lon")]
        public decimal Lon { get; set; }

        /// <summary>
        ///     Time zone name
        /// </summary>
        [JsonProperty("tz_id")]
        public string TimeZone { get; set; }

        /// <summary>
        ///     Local date and time
        /// </summary>
        [JsonProperty("localtime")]
        public string LocalTime { get; set; }
    }
}