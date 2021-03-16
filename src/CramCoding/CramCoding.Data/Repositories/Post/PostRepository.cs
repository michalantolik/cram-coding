using CramCoding.Domain.Entities;
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
        public Post FindByHeader(string header)
        {
            return this.context.Post.SingleOrDefault(p => p.Header == header);
        }
    }
}
