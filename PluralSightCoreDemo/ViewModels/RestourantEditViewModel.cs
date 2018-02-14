using PluralSightCoreDemo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PluralSightCoreDemo.ViewModels
{
    public class RestourantEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public TypeOfRestaurant TypeRestourant { get; set; }

        public IEnumerable<RestaurantCity> Cities { get; set; }

        public static implicit operator RestourantEditViewModel(Restaurant restaurant)
        {
            return new RestourantEditViewModel {Id = restaurant.Id, Name = restaurant.Name, TypeRestourant = restaurant.TypeRestaurant };
        }

        public static implicit operator Restaurant(RestourantEditViewModel vm)
        {
            return new Restaurant { Id = vm.Id, Name = vm.Name, TypeRestaurant = vm.TypeRestourant };
        }
    }
}
