using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.View.JsonApi
{
    class TemperatureInfo
    {
        public string Temp { get; set; }

        public string Feel_Like { get; set; }
        public string Pressure  { get; set; }
        public string Humidity { get; set; }
    }
}
