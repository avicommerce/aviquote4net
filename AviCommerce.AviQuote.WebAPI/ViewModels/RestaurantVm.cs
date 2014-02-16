using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AviCommerce.AviQuote.WebAPI.ViewModels
{
    public class RestaurantVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Cuisine { get; set; }
        public string Attire { get; set; }
        public string OperatingHours { get; set; }
        public double AverageMealCost { get; set; }
    }
}