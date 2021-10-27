using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Models
{
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Coordinates()
        {

        }
        public Coordinates(double lat, double lon)
        {
            this.Latitude = lat;
            this.Longitude = lon;
        }
    }
}
