using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.WeatherApi.Models
{
    public class Condition
    {
        /// <summary>
        /// Weather condition text
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Weather icon url
        /// </summary>
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Weather condition unique code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
    }
}
