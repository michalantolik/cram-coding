using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Repository used to manage <see cref="Category"/> entities
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Stores <see cref="Category"/> entity in the data storage
        /// </summary>
        /// <param name="category">Entity to be stored</param>
        void Add(Category category);

        /// <summary>
        /// Removes <see cref="Category"/> entity from the data storage
        /// </summary>
        /// <param name="category">Entity to be removed</param>
        void Delete(Category category);

        /// <summary>
        /// Finds <see cref="Category"/> entity in the data storage by ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns></returns>
        Category Find(int id);

        /// <summary>
        /// Reads out all <see cref="Category"/> entities from the data storage
        /// </summary>
        /// <param name="include">Include all related entities</param>
        /// <returns></returns>
        IQueryable<Category> GetAll(bool include = false);

        /// <summary>
        /// Updates <see cref="Category"/> entity in the data storage
        /// </summary>
        /// <param name="category">Entity to be updated</param>
        void Update(Category category);
    }
}
