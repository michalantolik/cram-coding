using CramCoding.WebApp.Models.EntityClasses;
using System.Linq;

namespace CramCoding.WebApp.Models.Repositories
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
