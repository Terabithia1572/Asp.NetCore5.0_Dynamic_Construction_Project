using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        //List<Product> GetListAll();
        //void AddProduct(Product product);
        //void DeleteProduct(Product product);
        //void UpdateProduct(Product product);
        //Product GetByID(int id);
    }
}
