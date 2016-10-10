using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProject
{
    //<summary>
    //  This class includes all the details about the requested location 
    //</summary>
    public class Location
    {
        private String city;
        private String country;
        private String temperature;
        private String humidity;
        private String pressure;
        private String wind;
        private String clouds;
        private String visibility;
        private String precipitation;
        private String lastupdate;
        private String id;
        private double lon;
        private double lat;
        

        public Location() { }

        public Location(String location)
        {
            city = location;
        }

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public String Country
        {
            get { return country; }
            set { country = value; }
        }

        public String Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public String Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        public String Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

        public String Wind
        {
            get { return wind; }
            set { wind = value; }
        }

        public String Clouds
        {
            get { return clouds; }
            set { clouds = value; }
        }

        public String Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }

        public String Precipitation
        {
            get { return precipitation; }
            set { precipitation = value; }
        }

        public String Lastupdate
        {
            get { return lastupdate; }
            set { lastupdate = value; }
        }

        public String ID
        {
            get { return id; }
            set { lastupdate = value; }
        }

        public double Lon
        {
            get { return lon; }
            set { lon = value; }
        }

        public double Lat
        {
            get { return lat; }
            set { lat = value; }
        }
    }
}
