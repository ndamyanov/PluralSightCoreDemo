using PluralSightCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightCoreDemo.Services
{
    public interface IImageData
    {
        void AddImage(Image image);

        IEnumerable<Image> GetAllImages();

        bool Delete(int id);
    }
}
