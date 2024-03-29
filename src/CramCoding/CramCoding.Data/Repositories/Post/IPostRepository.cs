﻿using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Interface used to manage <see cref="Post"> entities
    /// </summary>
    public interface IPostRepository : IRepository<Post>
    {
        /// <summary>
        /// Reads out all <see cref="Post"/> entities from the data storage
        /// </summary>
        /// <param name="include">Include all related entities</param>
        /// <returns>All <see cref="Post"/> entities</returns>
        IQueryable<Post> GetAll(bool include = false);

        /// <summary>
        /// Finds <see cref="Post"/> entity in the data storage by header
        /// </summary>
        /// <param name="header">Post header</param>
        /// <returns>Found <see cref="Post"/> entity or null</returns>
        Post FindByHeader(string header);
    }
}
