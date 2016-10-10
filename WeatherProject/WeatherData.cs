using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Net;

namespace WeatherProject
{
    //<summary>
    //  This class use the data service api to get all the details about the wanted location 
    //</summary>
    public class WeatherData : IWeatherDataService
    {
        private Location location;
        private String mapURL = "http://api.openweathermap.org/data/2.5/weather?q=";
        private String apiKey = "5ad9f7be62502fbf5a9a6422fae43ad9";
        private static WeatherData weatherData;
        String xml;

        public Location Location
        {
            get { return location; }
            set { location = value; }
        }

        public WeatherData()
        {

        }

        public static WeatherData Instance()
        {
            return weatherData == null ? new WeatherData() : weatherData;
        }

        public void SetUrl()
        {
            mapURL += location.City + "&mode=xml&appid=" + apiKey;
        }

        //<summary>
        //  This function extracts all the weather details from the xml 
        //</summary>
        public WeatherData GetWeatherData(Location loc)
        {
            location = loc;
            mapURL += location.City + "&mode=xml&appid=" + apiKey;
            double kelvin = 273.15;
            WebClient client = new WebClient();
            XDocument xmlDoc;
            try { 
                xml = client.DownloadString(mapURL); 
            }
            catch (Exception e) { 
                throw new WeatherDataServiceException(e, "Weather Data Exception"); 
            }
            
            try
            {
                xmlDoc = XDocument.Parse(xml);
                location.Temperature = Convert.ToString(double.Parse(xmlDoc.Descendants("temperature").Attributes("value").First().Value) - kelvin);
                location.Humidity = xmlDoc.Descendants("humidity").Attributes("value").First().Value;
                location.Pressure = xmlDoc.Descendants("pressure").Attributes("value").First().Value;
                location.Wind = xmlDoc.Descendants("speed").Attributes("name").First().Value;
                location.Clouds = xmlDoc.Descendants("clouds").Attributes("name").First().Value;
                location.Precipitation = xmlDoc.Descendants("precipitation").Attributes("mode").FirstOrDefault().Value;
                location.Lastupdate = xmlDoc.Descendants("lastupdate").Attributes("value").First().Value;
                location.Country = xmlDoc.Descendants("country").FirstOrDefault().Value;
                location.ID = xmlDoc.Descendants("city").Attributes("id").First().Value;
                location.Lon = Convert.ToDouble(xmlDoc.Descendants("coord").Attributes("lon").First().Value);
                location.Lat = Convert.ToDouble(xmlDoc.Descendants("coord").Attributes("lat").First().Value);
                if (xmlDoc.Descendants("visibility").Attributes("value").FirstOrDefault() != null)
                {
                    location.Visibility = xmlDoc.Descendants("visibility").Attributes("value").FirstOrDefault().Value;
                }
                else
                {
                    location.Visibility = "No Data";
                }
            }
            catch (WeatherDataServiceException e)
            {
                throw new WeatherDataServiceException(e, "XmlException");
            }

            return this;
        }

        public void PrintData()
        {
            Console.WriteLine("----- The Weather In : " + location.City + " -----\n" +
                              "Temperature: \t" + location.Temperature + " °C\n" +
                              "Humidity: \t" + location.Humidity + "%\n" +
                              "Pressure: \t" + location.Pressure + " hPa\n" +
                              "Wind: \t\t" + location.Wind + "\n" +
                              "Clouds: \t" + location.Clouds + "\n" +
                              "Visibility: \t" + location.Visibility + "\n" +
                              "Precipitation: \t" + location.Precipitation + "\n" +
                              "Lastupdate: \t" + location.Lastupdate + "\n");
        }
    }
}
