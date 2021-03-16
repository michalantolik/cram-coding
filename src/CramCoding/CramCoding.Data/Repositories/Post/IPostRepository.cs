using CramCoding.Domain.Entities;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Interface used to manage <see cref="Post"> entities
    /// </summary>
    public interface IPostRepository : IRepository<Post>
    {
        /// <summary>
        /// Finds <see cref="Post"/> entity in the data storage by header
        /// </summary>
        /// <param name="header">Post header</param>
        /// <returns>Found <see cref="Post"/> entity or null</returns>
        Post FindByHeader(string header);
    }
}
