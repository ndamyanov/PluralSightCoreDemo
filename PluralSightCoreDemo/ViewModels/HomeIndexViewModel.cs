using PluralSightCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightCoreDemo.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restourants { get; set; }

        public string CurrentMessage { get; set; }

        public IEnumerable<RestaurantCity> Cities { get; set; }
    }
}
