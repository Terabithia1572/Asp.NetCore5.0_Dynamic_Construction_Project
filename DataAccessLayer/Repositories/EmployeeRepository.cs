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
    public class EmployeeRepository : IEmployeeDal
    {
        Context context = new Context();
        public void AddEmployee(Employee employee)
        {
            context.Add(employee);
            context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            context.Remove(employee);
            context.SaveChanges();
        }

        public Employee GetByID(int id)
        {
            return context.Employees.Find(id);
        }

        public List<Employee> GetListAll()
        {
            return context.Employees.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Update(employee);
            context.SaveChanges();
        }
    }
}
