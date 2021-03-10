using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Repository used to manage <see cref="Tag"/> entities
    /// </summary>
    public interface ITagRepository
    {
        /// <summary>
        /// Stores <see cref="Tag"/> entity in the data storage
        /// </summary>
        /// <param name="tag">Entity to be stored</param>
        void Add(Tag tag);

        /// <summary>
        /// Removes <see cref="Tag"/> entity from the data storage
        /// </summary>
        /// <param name="tag">Entity to be removed</param>
        void Delete(Tag tag);

        /// <summary>
        /// Finds <see cref="Tag"/> entity in the data storage by ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Found <see cref="Tag"/> entity</returns>
        Tag Find(int id);

        /// <summary>
        /// Reads out all <see cref="Tag"/> entities from the data storage
        /// </summary>
        /// <param name="include">Include all related entities</param>
        /// <returns>All <see cref="Tag"/> entities</returns>
        IQueryable<Tag> GetAll();

        /// <summary>
        /// Updates <see cref="Tag"/> entity in the data storage
        /// </summary>
        /// <param name="tag">Entity to be updated</param>
        void Update(Tag tag);
    }
}
