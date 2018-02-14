using PluralSightCoreDemo.Models;
using System.Collections.Generic;

namespace PluralSightCoreDemo.Services
{
    public interface IRestourantData
    {
        IEnumerable<Restaurant> GetAll();

        Restaurant Get(int id);

        Restaurant Add(Restaurant newRestourant);
    }
}
