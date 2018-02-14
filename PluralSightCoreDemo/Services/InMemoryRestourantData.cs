using PluralSightCoreDemo.Models;
using PluralSightCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightCoreDemo.Services
{
    public class InMemoryRestourantData : IRestourantData
    {
        public InMemoryRestourantData()
        {
            _restourants = new List<Restaurant>
            {
                new Restaurant { Id=1, Name = "Scott's pizza" },
                new Restaurant { Id=2, Name = "John's pizza" },
                new Restaurant { Id=3, Name = "Boby's pizza" }
            };
        }

        List<Restaurant> _restourants;

        public IEnumerable<Restaurant> GetAll()
        {
            return _restourants;
        }

        public Restaurant Get(int id)
        {
            return _restourants.FirstOrDefault(x => x.Id == id);
        }

        public Restaurant Add(Restaurant restourant)
        {
            restourant.Id = _restourants.Max(r => r.Id) + 1;
            _restourants.Add(restourant);

            return restourant;
                
        }
    }
}


