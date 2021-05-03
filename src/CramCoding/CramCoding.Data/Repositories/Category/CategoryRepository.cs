using CramCoding.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Class used for persistence purposes of <see cref="Category"/> entities 
    /// </summary>
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        /// <inheritdoc/>
        public IQueryable<Category> GetAll(bool include = false)
        {
            return include
                ? this.context.Category
                    .Include(c => c.Parent)
                    .Include(c => c.Children)
                : this.context.Category;
        }

        /// <inheritdoc/>
        public Category FindByName(string name)
        {
            return this.context.Category.SingleOrDefault(c => c.Name == name);
        }
    }
}
