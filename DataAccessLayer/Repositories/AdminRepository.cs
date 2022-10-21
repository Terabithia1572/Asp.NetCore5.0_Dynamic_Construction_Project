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
    public class AdminRepository : IAdminDal
    {
        Context context = new Context();
        public void AddAdmin(Admin admin)
        {
            context.Add(admin);
            context.SaveChanges();
        }

        public void DeleteAdmin(Admin admin)
        {
            context.Remove(admin);
        }

        public Admin GetByID(int id)
        {
            return context.Admins.Find(id);
        }

        public List<Admin> ListAllAdmin()
        {
            return context.Admins.ToList();
        }

        public void UpdateAdmin(Admin admin)
        {
            context.Update(admin);
            context.SaveChanges();
        }
    }
}
