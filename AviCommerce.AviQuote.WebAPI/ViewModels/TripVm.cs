using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class TripVm
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Airplane { get; set; }
        public DateTime CreateDate { get; set; }
        public string From { get; set; }
        public DateTime EstimatedTakeOff { get; set; }
        public string To { get; set; }
        public DateTime EstimatedLanding { get; set; }

        public bool IsEditable { get; set; }
        public DateTime CompletedDate { get; set; }

        public double EstimatedFuelCost { get; set; }
        public double EstimatedHandlingCost { get; set; }
        public double EstimatedNavigationFeesCost { get; set; }
        public double EstimatedAirportFeesCost { get; set; }

        public List<TripLegVm> Legs { get; set; }
        public List<TripStopVm> Stops { get; set; }
    }
}