using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Interface used to manage <see cref="Category"/> entities
    /// </summary>/// 
    public interface ICategoryRepository : IRepository<Category>
    {
        /// <summary>
        /// Reads out all <see cref="Category"/> entities from the data storage
        /// </summary>
        /// <param name="include">Include all related entities</param>
        /// <returns>All <see cref="Category"/> entities</returns>
        IQueryable<Category> GetAll(bool include = false);

        /// <summary>
        /// Finds <see cref="Category"/> entity in the data storage by name
        /// </summary>
        /// <param name="name">Category name</param>
        /// <returns>Found <see cref="Category"/> entity or null</returns>
        Category FindByName(string name);
    }
}
