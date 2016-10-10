using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProject
{
    //<summary>
    //  This class is a factory suited to any wanted service
    //</summary>
    public class WeatherDataServiceFactory
    {
        public static String OPEN_WEATHER_MAP = "OPEN_WEATHER_MAP";

        //<summary>
        //  This function returns the correct weather data according to the requested data service
        //</summary>
        public static WeatherData GetWeatherDataService(String info)
        {
            if (info.Equals(OPEN_WEATHER_MAP)) return WeatherData.Instance();
            return WeatherData.Instance();
        }
    }
}
