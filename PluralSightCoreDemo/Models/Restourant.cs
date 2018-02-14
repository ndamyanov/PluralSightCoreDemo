using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightCoreDemo.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public TypeOfRestaurant TypeRestaurant { get; set; }

        public IEnumerable<RestaurantCity> Cities { get; set; }
    }
}
