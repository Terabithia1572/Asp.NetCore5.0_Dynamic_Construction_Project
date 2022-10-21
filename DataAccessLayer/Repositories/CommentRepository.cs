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
    public class CommentRepository : ICommentDal
    {
        Context context = new Context();
        public void AddComment(Comment comment)
        {
            context.Add(comment);
            context.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            context.Remove(comment);
            context.SaveChanges();
        }

        public Comment GetByID(int id)
        {
            return context.Comments.Find(id);
        }

        public List<Comment> GetListAll()
        {
            return context.Comments.ToList();
        }

        public void UpdateComment(Comment comment)
        {
            context.Update(comment);
            context.SaveChanges();
        }
    }
}
