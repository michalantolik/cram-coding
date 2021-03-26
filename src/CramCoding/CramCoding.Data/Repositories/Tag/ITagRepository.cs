using CramCoding.Domain.Entities;

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
    }
}
