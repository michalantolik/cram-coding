using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Interface used to manage <see cref="Tag"/> entities
    /// </summary>
    public interface ITagRepository : IRepository<Tag>
    {
        /// <summary>
        /// Finds <see cref="Tag"/> entity in the data storage by name
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <returns>Found <see cref="Tag"/> entity or null</returns>
        Tag FindByName(string name);

        /// <summary>
        /// Reads out all <see cref="Tag"/> entities from the data storage
        /// </summary>
        /// <param name="include">Include all related entities</param>
        /// <returns>All <see cref="Tag"/> entities</returns>
        IQueryable<Tag> GetAll(bool include = false);
    }
}
