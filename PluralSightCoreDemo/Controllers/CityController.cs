using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PluralSightCoreDemo.Models;
using PluralSightCoreDemo.Services;
using PluralSightCoreDemo.ViewModels;

namespace PluralSightCoreDemo.Controllers
{
    public class CityController : Controller
    {
        private ICityRepository _cityRepo;

        public CityController(ICityRepository cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public IActionResult Index()
        {
            var cityEntities = _cityRepo.GetAll();

            var model = Mapper.Map<IEnumerable<CityIndexViewModel>>(cityEntities);

            return View(model);
        }

        public IActionResult GetRestaurant(int id)
        {
            var restaurant = _cityRepo.GetById(id);
            var model = Mapper.Map<City, CityViewModel>(restaurant);

            return Ok(model);
        }
    }
}