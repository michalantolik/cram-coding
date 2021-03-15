using CramCoding.Domain.Entities;

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
    }
}
