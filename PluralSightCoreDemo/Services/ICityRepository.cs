using PluralSightCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightCoreDemo.Services
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();

        City GetById(int id);
        
    }
}
