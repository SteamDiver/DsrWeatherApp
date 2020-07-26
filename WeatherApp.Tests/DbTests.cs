using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApp.Data;
using WeatherApp.Data.Models;

namespace WeatherApp.Tests
{
    [TestClass]
    public class DbTests
    {
        [TestMethod]
        public async Task TestDb_AddVoronezh_RecordAdded()
        {
            using (var dataContext = new DataContext())
            {
                dataContext.CurrentWeather.RemoveRange(dataContext.CurrentWeather);
                await dataContext.SaveChangesAsync();

                var cityName = Guid.NewGuid().ToString();
                var weather = new CurrentWeather
                {
                    City = cityName
                };

                dataContext.CurrentWeather.AddOrUpdate(weather);
                await dataContext.SaveChangesAsync();

                Assert.IsTrue(dataContext.CurrentWeather.Any(w => w.City == cityName));

                dataContext.CurrentWeather.RemoveRange(dataContext.CurrentWeather);
                await dataContext.SaveChangesAsync();
            }
        }
    }
}