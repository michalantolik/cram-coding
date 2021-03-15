using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Generic interface for base repository class
    /// </summary>
    /// <typeparam name="TEntity">Type of entity to be managed</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Stores <see cref="TEntity"/> entity in the data storage
        /// </summary>
        /// <param name="entity">Entity to be stored</param>
        void Add(TEntity entity);

        /// <summary>
        /// Updates <see cref="TEntity"/> entity in the data storage
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        void Update(TEntity entity);

        /// <summary>
        /// Removes <see cref="TEntity"/> entity from the data storage
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Reads out all <see cref="TEntity"/> entities from the data storage
        /// </summary>
        /// <returns>All <see cref="TEntity"/> entities</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Finds <see cref="TEntity"/> entity in the data storage by ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Found <see cref="TEntity"/> entity</returns>
        TEntity Find(int id);
    }
}
