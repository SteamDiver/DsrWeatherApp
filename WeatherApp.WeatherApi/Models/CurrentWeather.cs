using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.WeatherApi.Models
{
    public class CurrentWeather
    {
        /// <summary>
        /// Temperature in C
        /// </summary>
        [JsonProperty(PropertyName = "temp_c")]
        public decimal Temperature { get; set; }

        /// <summary>
        /// Relative humidity
        /// </summary>
        [JsonProperty(PropertyName = "humidity")]
        public decimal Humidity { get; set; }

        /// <summary>
        /// Pressure in mb
        /// </summary>
        [JsonProperty(PropertyName = "pressure_mb")]
        public decimal Pressure { get; set; }

        /// <summary>
        /// Weather condition summary
        /// </summary>
        [JsonProperty(PropertyName = "condition")]
        public Condition Condition { get; set; }

        /// <summary>
        /// Wind speed in kilometer per hour
        /// </summary>
        [JsonProperty(PropertyName = "wind_kph")]
        public decimal WindSpeed { get; set; }

        /// <summary>
        /// Wind direction as 16 point compass. e.g.: NSW
        /// </summary>
        [JsonProperty(PropertyName = "wind_dir")]
        public string WindDir { get; set; }
    }
}
