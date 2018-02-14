using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightCoreDemo.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
