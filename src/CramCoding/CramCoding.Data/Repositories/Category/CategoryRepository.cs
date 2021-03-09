using CramCoding.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public IQueryable<Category> GetAll(bool include = false)
        {
            return include
                ? this.context.Category.Include(c => c.Children)
                : this.context.Category;
        }

        /// <inheritdoc/>
        public Category Find(int id)
        {
            return this.context.Category.Find(id);
        }

        /// <inheritdoc/>
        public void Add(Category category)
        {
            this.context.Category.Add(category);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Update(Category category)
        {
            this.context.Category.Update(category);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Category category)
        {
            this.context.Category.Remove(category);
            this.context.SaveChanges();
        }
    }
}
