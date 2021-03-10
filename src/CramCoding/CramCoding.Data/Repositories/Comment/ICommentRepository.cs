using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Repository used to manage <see cref="Comment"/> entities
    /// </summary>
    public interface ICommentRepository
    {
        /// <summary>
        /// Stores <see cref="Comment"/> entity in the data storage
        /// </summary>
        /// <param name="comment">Entity to be stored</param>
        void Add(Comment comment);

        /// <summary>
        /// Removes <see cref="Comment"/> entity from the data storage
        /// </summary>
        /// <param name="comment">Entity to be removed</param>
        void Delete(Comment comment);

        /// <summary>
        /// Finds <see cref="Comment"/> entity in the data storage by ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Found <see cref="Comment"/> entity</returns>
        Comment Find(int id);

        /// <summary>
        /// Reads out all <see cref="Comment"/> entities from the data storage
        /// </summary>
        /// <param name="include">Include all related entities</param>
        /// <returns>All <see cref="Comment"/> entities</returns>
        IQueryable<Comment> GetAll();

        /// <summary>
        /// Updates <see cref="Comment"/> entity in the data storage
        /// </summary>
        /// <param name="comment">Entity to be updated</param>
        void Update(Comment comment);
    }
}
