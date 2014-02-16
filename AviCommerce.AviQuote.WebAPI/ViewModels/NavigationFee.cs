using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class NavigationFee
    {
        public string Type { get; set; }
        public string Country { get; set; }
        public double Fee { get; set; }
    }
}
