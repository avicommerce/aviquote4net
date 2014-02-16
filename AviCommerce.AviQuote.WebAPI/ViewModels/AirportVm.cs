using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class AirportVm
    {
        public string IataSymbol { get; set; }
        public string IcoaSymbol { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public List<FuelSupplierVm> FuelSuppliers { get; set; }
        public List<AircraftHandlerVm> Handlers { get; set; }
        public List<AirportFeeVm> Fees { get; set; }
    }
}