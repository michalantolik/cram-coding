using CramCoding.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        /// <inheritdoc/>
        public Tag FindByName(string name)
        {
            return this.context.Tag.SingleOrDefault(t => t.Name == name);
        }

        /// <inheritdoc/>
        public IQueryable<Tag> GetAll(bool include = false)
        {
            return include 
                ? this.context.Tag.Include(t => t.Posts)
                : this.context.Tag;
        }
    }
}
