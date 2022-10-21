using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
        ICategoryDal _ICategoryDal;

        public CategoryManager(ICategoryDal ıCategoryDal)
        {
            _ICategoryDal = ıCategoryDal;
        }

        public List<Category> GetList()
        {
            return _ICategoryDal.GetListAll();
        }

        public void TAdd(Category t)
        {
            _ICategoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _ICategoryDal.Delete(t);
        }

        public Category TGetByID(int id)
        {
            return _ICategoryDal.GetByID(id);
        }

        public void TUpdate(Category t)
        {
            _ICategoryDal.Update(t);
        }


    }
}
