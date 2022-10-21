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
    public class ProductRepository : IProductDal
    {
        Context context = new Context();
        public void AddProduct(Product product)
        {
            context.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Remove(product);
            context.SaveChanges();
        }

        public Product GetByID(int id)
        {
            return context.Products.Find(id);
        }

        public List<Product> GetListAll()
        {
            return context.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            context.Update(product);
            context.SaveChanges();
        }
    }
}
