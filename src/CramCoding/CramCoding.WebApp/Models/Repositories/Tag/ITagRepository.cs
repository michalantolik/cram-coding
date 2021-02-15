using CramCoding.WebApp.Models.EntityClasses;
using System.Linq;

namespace CramCoding.WebApp.Models.Repositories
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
