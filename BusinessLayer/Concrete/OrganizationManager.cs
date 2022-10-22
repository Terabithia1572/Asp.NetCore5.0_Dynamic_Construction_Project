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
    public class OrganizationManager : IOrganizationService
    {
        IOrganizationDal _organizationDal;

        public OrganizationManager(IOrganizationDal organizationDal)
        {
            _organizationDal = organizationDal;
        }

        public List<Organization> GetList()
        {
           return _organizationDal.GetListAll();
        }

        public void TAdd(Organization t)
        {
            _organizationDal.Insert(t);
        }

        public void TDelete(Organization t)
        {
            _organizationDal.Delete(t);
        }

        public Organization TGetByID(int id)
        {
            return _organizationDal.GetByID(id);
        }

        public void TUpdate(Organization t)
        {
            _organizationDal.Update(t);
        }
    }
}
