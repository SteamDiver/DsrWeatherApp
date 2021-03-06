﻿using Newtonsoft.Json;

namespace WeatherApp.WeatherApi.Models
{
    public class WeatherApiResponse
    {
        /// <summary>
        ///     Requested location info
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}