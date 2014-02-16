using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class FuelSupplierVm
    {
        public string Name { get; set; }
        public string YearEstablished { get; set; }
        public double AveragePrice { get; set; }
        public double LatestPrice { get; set; }
    }
}