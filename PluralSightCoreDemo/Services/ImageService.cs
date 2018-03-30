using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluralSightCoreDemo.Data;
using PluralSightCoreDemo.Models;

namespace PluralSightCoreDemo.Services
{
    public class ImageService : IImageData
    {
        private PluralSightDemoDbContext _context;
        public ImageService(PluralSightDemoDbContext context)
        {
            _context = context;
        }
        public void AddImage(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var img = _context.Images.Where(x => x.Id == id).FirstOrDefault();
            if(img != null)
            {
                _context.Images.Remove(img);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _context.Images.ToList();
        }

        public Image ViewImage(int id)
        {
            return  _context.Images.Where(i => i.Id == id).FirstOrDefault();
               
        }
    }
}
