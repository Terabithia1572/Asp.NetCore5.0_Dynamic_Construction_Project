using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EfImageRepository : IImageDal
    {
        Context context = new Context();
        public void AddImage(Image image)
        {
            context.Add(image);
            context.SaveChanges();
        }

        public void DeleteImage(Image image)
        {
            context.Remove(image);
            context.SaveChanges();
        }

        public Image GetByID(int id)
        {
            return context.Images.Find(id);
        }

        public List<Image> GetListAll()
        {
            return context.Images.ToList();
        }

        public void UpdateImage(Image image)
        {
            context.Update(image);
            context.SaveChanges();
        }
    }
}
