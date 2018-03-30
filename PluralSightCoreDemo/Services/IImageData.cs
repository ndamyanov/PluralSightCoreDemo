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

        Image ViewImage(int id);

        bool Delete(int id);
    }
}
