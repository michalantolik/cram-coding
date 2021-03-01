using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Delete(Category category);
        Category Find(int id);
        IQueryable<Category> GetAll();
        void Update(Category category);
    }
}
