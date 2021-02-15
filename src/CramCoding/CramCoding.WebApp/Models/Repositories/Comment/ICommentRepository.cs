using CramCoding.WebApp.Models.EntityClasses;
using System.Linq;

namespace CramCoding.WebApp.Models.Repositories
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        void Delete(Comment comment);
        Comment Find(int id);
        IQueryable<Comment> GetAll();
        void Update(Comment comment);
    }
}
