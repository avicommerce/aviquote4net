using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class DestinationSummaryVm
    {
        public string City { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public int Airports { get; set; }
        public int Hospitals { get; set; }
        public int Restaurants { get; set; }
    }
}