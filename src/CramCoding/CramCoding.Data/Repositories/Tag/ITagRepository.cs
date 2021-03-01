using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    public interface ITagRepository
    {
        void Add(Tag tag);
        void Delete(Tag tag);
        Tag Find(int id);
        IQueryable<Tag> GetAll();
        void Update(Tag tag);
    }
}
