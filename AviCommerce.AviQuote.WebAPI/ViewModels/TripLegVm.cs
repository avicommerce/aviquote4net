using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class TripLegVm
    {
        public string Identifier { get; set; }
        public string TripIdentifier { get; set; }
        public string From { get; set; }
        public DateTime EstimatedTakeOff { get; set; }
        public string To { get; set; }
        public DateTime EstimatedLanding { get; set; }

        public double EstimatedFuelCost { get; set; }
        public double EstimatedHandlingCost { get; set; }
        public double EstimatedNavigationFeesCost { get; set; }

        public List<NavigationFee> NavigationFees { get; set; }
    }
}