using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    public interface ITagRepository
    {
        void Add(Tag category);
        void Delete(Tag category);
        Tag Find(int id);
        IQueryable<Tag> GetAll();
        void Update(Tag category);
    }
}
