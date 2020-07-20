using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Data.Models
{
    public class CurrentWeather
    {
        [Key]
        public string City { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal Pressure { get; set; }
        public string CondText { get; set; }
        public string CondIcon { get; set; }
        public decimal WindSpeed { get; set; }
        public string WindDir { get; set; }

    }
}
