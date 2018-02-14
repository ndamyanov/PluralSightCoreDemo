
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PluralSightCoreDemo.Models;
using PluralSightCoreDemo.Services;
using PluralSightCoreDemo.ViewModels;
using AutoMapper.QueryableExtensions;

namespace PluralSightCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private IRestourantData _data;
        private IGreater _greeter;
        private ILogger<Restaurant> _logger;

        public HomeController(IRestourantData data, IGreater greeter, ILogger<Restaurant> logger)
        {
            _logger = logger;
            _data = data;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restourants = _data.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _data.Get(id);
            if(model == null)
            {
                return BadRequest();
            }
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestourantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Restaurant newRestourant = model;
                
                newRestourant = _data.Add(newRestourant);

                _logger.LogInformation(newRestourant.Id.ToString());

                return RedirectToAction(nameof(Details), new { id = newRestourant.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
