using CramCoding.Domain.Entities;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Class used for persistence purposes of <see cref="Tag"/> entities 
    /// </summary>
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {

        }
    }
}
