using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext context;

        public TagRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public IQueryable<Tag> GetAll()
        {
            return this.context.Tag;
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public Tag Find(int id)
        {
            return this.context.Tag.Find(id);
        }

        /// <inheritdoc/>
        public void Add(Tag tag)
        {
            this.context.Tag.Add(tag);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Update(Tag tag)
        {
            this.context.Tag.Update(tag);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Tag tag)
        {
            this.context.Tag.Remove(tag);
            this.context.SaveChanges();
        }
    }
}
