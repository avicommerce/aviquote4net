using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class DestinationVm
    {
        public string City { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string TimeZone { get; set; }
        public string VisaRequirement { get; set; }
        public string Climate { get; set; }

        public List<AirportVm> Airports { get; set; }
        public List<HospitalVm> Hospitals { get; set; }
        public List<RestaurantVm> Restaurants { get; set; }
        public List<WeatherForecast> WeatherPreviousDays { get; set; }
        public List<WeatherForecast> WeatherForwardDays { get; set; }
    }
}