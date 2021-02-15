using CramCoding.WebApp.Models.EntityClasses;
using System.Linq;

namespace CramCoding.WebApp.Models.Repositories
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