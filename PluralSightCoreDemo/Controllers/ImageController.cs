using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System;
using PluralSightCoreDemo.ViewModels;
using PluralSightCoreDemo.Models;
using PluralSightCoreDemo.Data;
using PluralSightCoreDemo.Services;
using Microsoft.AspNetCore.Http;

namespace PluralSightCoreDemo.Controllers
{
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly IImageData _imgService;

        public ImageController(IHostingEnvironment env, IImageData imgService)
        {
            _environment = env;
            _imgService = imgService;
        }
        public IActionResult Index()
        {
            IEnumerable<Image> images = _imgService.GetAllImages();
            return View(images);
        }

        //public IActionResult InsertImage()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult InsertImage(string name)
        //{
        //    var newFileName = string.Empty;

        //    if (HttpContext.Request.Form.Files != null)
        //    {
        //        var fileName = string.Empty;
        //        string PathDB = string.Empty;

        //        var files = HttpContext.Request.Form.Files;

        //        foreach (var file in files)
        //        {
        //            if (file.Length > 0)
        //            {
        //                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

        //                var myUniqueFileName = Convert.ToString(Guid.NewGuid());

        //                var FileExtension = Path.GetExtension(fileName);

        //                newFileName = myUniqueFileName + FileExtension;

        //                fileName = Path.Combine(_environment.WebRootPath, "Images") + $@"\{newFileName}";

        //                // if you want to store path of folder in database
        //                PathDB = "demoImages/" + newFileName;

        //                using (FileStream fs = System.IO.File.Create(fileName))
        //                {
        //                    file.CopyTo(fs);
        //                    fs.Flush();
        //                }
        //            }
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        //[ActionName("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var image = new Image();

                using(var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    image.ImageData = memoryStream.ToArray();

                    _imgService.AddImage(image);
                }
              return RedirectToAction(nameof(Index));
            }
            return BadRequest("Something goes wrong");
        }

        [HttpDelete]
        //[Route("Remove/{id}")]
        public IActionResult RemoveImage(int id)
        {
            if (_imgService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest("No image found");
        }
    }
}