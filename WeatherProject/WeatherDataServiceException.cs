using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProject
{
    //<summary>
    //  This class handles the weather data exceptions 
    //</summary>
    class WeatherDataServiceException : ApplicationException
    {
        public WeatherDataServiceException(Exception e, String msg)
            : base(msg)
        {
            Console.WriteLine("Couldnt read data properly from XML document.\n" + msg);
        }
    }
}
