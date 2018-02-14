using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightCoreDemo.Models
{
    public class RestaurantCity
    {
        public int CityId { get; set; }
        public City CityData { get; set; }

        public int ReataurantId { get; set; }
        public Restaurant RestaurantData { get; set; }
    }
}
