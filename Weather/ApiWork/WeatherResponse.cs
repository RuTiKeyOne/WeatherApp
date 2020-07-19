using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.View.JsonApi
{
    class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }

        public WindInfo Wind { get; set; }
        public string Name { get; set; }
    }
}
