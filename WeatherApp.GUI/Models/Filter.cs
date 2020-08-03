using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.GUI.Models
{
    public class Filter
    {
        public string CityName { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? Pressure { get; set; }
        public string Description { get; set; }
        public decimal? WindSpeed { get; set; }
        public string WindDir { get; set; }

        public bool GetFilter(CurrentWeatherRow obj)
        {
            return obj.Weather.CityName.Contains(CityName ?? "") &&
                   obj.Weather.CondText.Contains(Description ?? "") &&
                   (Temperature == null || obj.Weather.Temperature == Temperature) &&
                   (Humidity == null || obj.Weather.Humidity == Humidity) &&
                   (Pressure == null || obj.Weather.Pressure == Pressure) &&
                   (WindDir == null || obj.Weather.WindDir == WindDir) &&
                   (WindSpeed == null || obj.Weather.WindSpeed == WindSpeed);
        }
    }
}