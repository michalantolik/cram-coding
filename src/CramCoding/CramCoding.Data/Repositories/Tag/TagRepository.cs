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

        public IQueryable<Tag> GetAll()
        {
            return this.context.Tag;
            this.context.SaveChanges();
        }

        public Tag Find(int id)
        {
            return this.context.Tag.Find(id);
        }

        public void Add(Tag tag)
        {
            this.context.Tag.Add(tag);
            this.context.SaveChanges();
        }

        public void Update(Tag tag)
        {
            this.context.Tag.Update(tag);
            this.context.SaveChanges();
        }

        public void Delete(Tag tag)
        {
            this.context.Tag.Remove(tag);
            this.context.SaveChanges();
        }
    }
}
