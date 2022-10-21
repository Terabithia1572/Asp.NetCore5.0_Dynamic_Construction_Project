using BusinessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public List<Category> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Category t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Category t)
        {
            throw new NotImplementedException();
        }

        public Category TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
