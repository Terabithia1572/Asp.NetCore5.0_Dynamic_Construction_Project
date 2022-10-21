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
    public class EfContactRepository : IContactDal
    {
        Context context = new Context();
        public void AddContact(Contact contact)
        {
            context.Add(contact);
            context.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            context.Remove(contact);
            context.SaveChanges();
        }

        public Contact GetByID(int id)
        {
            return context.Contacts.Find(id);
        }

        public List<Contact> GetListAll()
        {
            return context.Contacts.ToList();

        }

        public void UpdateContact(Contact contact)
        {
            context.Update(contact);
            context.SaveChanges();
        }
    }
}
