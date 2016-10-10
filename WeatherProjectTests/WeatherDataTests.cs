using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeatherProject.Tests
{
    [TestClass()]
    public class WeatherDataTests
    {
        [TestMethod()]
        public void GetWeatherDataTest()
        {
            WeatherData weather = new WeatherData();
            weather.GetWeatherData(new Location("London"));
            
            Location loc = new Location();
            loc.ID = "2643743";
            loc.Country = "GB";
            loc.City = "London";
            loc.Lon = -0.13;
            loc.Lat = 51.51;

            Assert.IsNotNull(weather);
            Assert.AreEqual(loc.ID, weather.Location.ID);
            Assert.AreEqual(loc.Country, weather.Location.Country);
            Assert.AreEqual(loc.City, weather.Location.City);
            Assert.AreEqual(loc.Lat, weather.Location.Lat);
            Assert.AreEqual(loc.Lon, weather.Location.Lon);
        }
    }
}
