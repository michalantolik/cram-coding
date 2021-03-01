using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Delete(Post post);
        Post Find(int id);
        IQueryable<Post> GetAll();
        void Update(Post post);
    }
}