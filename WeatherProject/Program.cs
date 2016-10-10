using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IWeatherDataService service = WeatherDataServiceFactory.GetWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
                WeatherData weatherData = service.GetWeatherData(new Location("London"));
                weatherData.PrintData();
            }
            catch (WeatherDataServiceException e)
            {
                throw new WeatherDataServiceException(e, "XmlException");
            }
            return;
        }
    }
}
