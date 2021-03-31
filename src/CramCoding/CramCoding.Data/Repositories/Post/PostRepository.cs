using CramCoding.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Class used for persistence purposes of <see cref="Post"/> entities 
    /// </summary>
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {

        }

        /// <inheritdoc/>
        public IQueryable<Post> GetAll(bool include = false)
        {
            return include
                ? this.context.Post
                    .Include(c => c.Author)
                    .Include(c => c.Categories)
                    .Include(c => c.Tags)
                    .Include(c => c.Comments)
                : this.context.Post;
        }

        /// <inheritdoc/>
        public Post FindByHeader(string header)
        {
            return this.context.Post.SingleOrDefault(p => p.Header == header);
        }
    }
}
