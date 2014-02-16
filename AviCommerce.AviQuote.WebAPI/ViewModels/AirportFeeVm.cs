using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class AirportFeeVm
    {
        public string Name { get; set; }
        public string Terms { get; set; }
        public double Fee { get; set; }
    }
}