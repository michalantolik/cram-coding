using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext context;

        public PostRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Post> GetAll()
        {
            return this.context.Post;
        }

        public Post Find(int id)
        {
            return this.context.Post.Find(id);
        }

        public void Add(Post post)
        {
            this.context.Post.Add(post);
            this.context.SaveChanges();
        }

        public void Update(Post post)
        {
            this.context.Post.Update(post);
            this.context.SaveChanges();
        }

        public void Delete(Post post)
        {
            this.context.Post.Remove(post);
            this.context.SaveChanges();
        }
    }
}
