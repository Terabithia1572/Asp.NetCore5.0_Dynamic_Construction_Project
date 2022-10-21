using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        public List<Employee> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Employee t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Employee t)
        {
            throw new NotImplementedException();
        }

        public Employee TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
