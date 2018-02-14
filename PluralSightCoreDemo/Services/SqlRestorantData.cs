using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluralSightCoreDemo.Data;
using PluralSightCoreDemo.Models;
using PluralSightCoreDemo.ViewModels;

namespace PluralSightCoreDemo.Services
{
    public class SqlRestorantData : IRestourantData
    {
        private PluralSightDemoDbContext _context;

        public SqlRestorantData(PluralSightDemoDbContext context)
        {
            this._context = context;
        }
        public Restaurant Add(Restaurant newRestourant)
        {
            this._context.Add(newRestourant);
            _context.SaveChanges();
            return newRestourant;
        }

        public Restaurant Get(int id)
        {
            return this._context.Restourants.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return this._context.Restourants;
        }
    }
}
