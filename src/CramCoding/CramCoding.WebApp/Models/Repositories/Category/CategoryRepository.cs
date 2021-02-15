using CramCoding.WebApp.Models.EntityClasses;
using System.Linq;

namespace CramCoding.WebApp.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Category> GetAll()
        {
            return this.context.Category;
        }

        public Category Find(int id)
        {
            return this.context.Category.Find(id);
        }

        public void Add(Category category)
        {
            this.context.Category.Add(category);
            this.context.SaveChanges();
        }

        public void Update(Category category)
        {
            this.context.Category.Update(category);
            this.context.SaveChanges();
        }

        public void Delete(Category category)
        {
            this.context.Category.Remove(category);
            this.context.SaveChanges();
        }
    }
}
