using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class WeatherForecast
    {
        public string Day { get; set; }
        public string Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public int Wind { get; set; }
        public int Rain { get; set; }
    }
}