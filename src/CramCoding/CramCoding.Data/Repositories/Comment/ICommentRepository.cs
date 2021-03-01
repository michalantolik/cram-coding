using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
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
