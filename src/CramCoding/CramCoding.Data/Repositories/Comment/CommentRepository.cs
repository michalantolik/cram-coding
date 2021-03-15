using CramCoding.Domain.Entities;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Class used for persistence purposes of <see cref="Comment"/> entities 
    /// </summary>
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(AppDbContext context) : base(context)
        {

        }
    }
}
