using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.WeatherApi.Models
{
    public class WeatherApiResponse
    {
        /// <summary>
        /// Requested location info
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }
    }
}
