using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Repository used to manage <see cref="Post"/> entities
    /// </summary>
    public interface IPostRepository
    {
        /// <summary>
        /// Stores <see cref="Post"/> entity in the data storage
        /// </summary>
        /// <param name="post">Entity to be stored</param>
        void Add(Post post);

        /// <summary>
        /// Removes <see cref="Post"/> entity from the data storage
        /// </summary>
        /// <param name="post">Entity to be removed</param>
        void Delete(Post post);

        /// <summary>
        /// Finds <see cref="Post"/> entity in the data storage by ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Found <see cref="Post"/> entity</returns>
        Post Find(int id);

        /// <summary>
        /// Reads out all <see cref="Post"/> entities from the data storage
        /// </summary>
        /// <param name="include">Include all related entities</param>
        /// <returns>All <see cref="Post"/> entities</returns>
        IQueryable<Post> GetAll();

        /// <summary>
        /// Updates <see cref="Post"/> entity in the data storage
        /// </summary>
        /// <param name="post">Entity to be updated</param>
        void Update(Post post);
    }
}
