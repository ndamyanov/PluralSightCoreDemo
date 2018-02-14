
using Microsoft.AspNetCore.Mvc;

namespace PluralSightCoreDemo.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        public IActionResult Phone()
        {
            return View("Phone", "1-555-654-895");
        }

       [Route("address")]
        public string Address()
        {
            return "USA";
        }
    }
}
