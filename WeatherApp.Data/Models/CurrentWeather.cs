using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Data.Models
{
    public class CurrentWeather
    {
        [Key] public string City { get; set; }

        public string CityName { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal Pressure { get; set; }
        public string CondText { get; set; }
        public string CondIcon { get; set; }
        public decimal WindSpeed { get; set; }
        public string WindDir { get; set; }
    }
}