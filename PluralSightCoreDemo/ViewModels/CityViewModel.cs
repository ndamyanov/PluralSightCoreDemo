using PluralSightCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightCoreDemo.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
