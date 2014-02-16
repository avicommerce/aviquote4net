using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class TripStopVm
    {
        public string Identifier { get; set; }
        public string TripIdentifier { get; set; }
        public string Stop { get; set; }
        public string Destination { get; set; }
        public DateTime EstimatedTakeOff { get; set; }
        public DateTime EstimatedLanding { get; set; }
        public bool IsOrigin { get; set; }
        public bool IsDestination { get; set; }
        public bool IsTechnical { get; set; }
        
        public int Order { get; set; }

        public double EstimatedFuelCost { get; set; }
        public double EstimatedHandlingCost { get; set; }
        public double EstimatedAirportFeesCost { get; set; }

        public double FuelGallons { get; set; }
        public double FuelPricePerGallon { get; set; }
        public string FuelSupplier { get; set; }
        public bool IsFuelOrdered { get; set; }
        public DateTime FuelOrderedDate { get; set; }

        public string Handler { get; set; }
        public bool IsHandlingOrdered { get; set; }
        public DateTime HandlingOrderedDate { get; set; }

        public List<AirportFee> AirportFees { get; set; }
    }
}