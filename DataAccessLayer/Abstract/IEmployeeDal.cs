using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
  public interface IEmployeeDal : IGenericDal<Employee>
    {
        //List<Employee> GetListAll();
        //void AddEmployee(Employee employee);
        //void DeleteEmployee(Employee employee);
        //void UpdateEmployee(Employee employee);
        //Employee GetByID(int id);

    }
}
