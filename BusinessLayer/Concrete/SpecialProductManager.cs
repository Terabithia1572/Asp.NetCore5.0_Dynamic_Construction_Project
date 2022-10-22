using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SpecialProductManager : ISpecialProductService
    {
        ISpecialProductDal _specialProductDal;

        public SpecialProductManager(ISpecialProductDal specialProductDal)
        {
            _specialProductDal = specialProductDal;
        }

        public List<SpecialProduct> GetList()
        {
            return _specialProductDal.GetListAll();
        }

        public void TAdd(SpecialProduct t)
        {
            _specialProductDal.Insert(t);
        }

        public void TDelete(SpecialProduct t)
        {
            _specialProductDal.Delete(t);
        }

        public SpecialProduct TGetByID(int id)
        {
            return _specialProductDal.GetByID(id);
        }

        public void TUpdate(SpecialProduct t)
        {
            _specialProductDal.Update(t);
        }
    }
}
