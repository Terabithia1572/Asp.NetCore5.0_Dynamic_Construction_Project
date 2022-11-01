using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=ConstructionDBV.mssql.somee.com;packet size=4096;user id=Terabithia15721_SQLLogin_1;pwd=s7ec8ia2fl;data source=ConstructionDBV.mssql.somee.com;persist security info=False;initial catalog=ConstructionDBV");

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment>Comments { get; set; }
        public DbSet<Contact>Contacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SpecialProduct> SpecialProducts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
       

    }
}
