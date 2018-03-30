using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PluralSightCoreDemo.Controllers
{
    public class ForumController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}