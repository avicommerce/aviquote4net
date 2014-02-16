using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class AirplaneSummaryVm
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Year { get; set; }
    }
}