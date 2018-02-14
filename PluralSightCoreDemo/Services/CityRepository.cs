using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PluralSightCoreDemo.Data;
using PluralSightCoreDemo.Models;

namespace PluralSightCoreDemo.Services
{
    public class CityRepository : ICityRepository
    {
        private PluralSightDemoDbContext _context;

        public CityRepository(PluralSightDemoDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public City GetById(int id)
        {
            return _context.Cities.Where(c => c.Id == id).Include(c => c.Restaurants).FirstOrDefault();
        }
    }
}
