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

        /// <inheritdoc/>
        public IQueryable<Post> GetAll()
        {
            return this.context.Post;
        }

        /// <inheritdoc/>
        public Post Find(int id)
        {
            return this.context.Post.Find(id);
        }

        /// <inheritdoc/>
        public void Add(Post post)
        {
            this.context.Post.Add(post);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Update(Post post)
        {
            this.context.Post.Update(post);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Post post)
        {
            this.context.Post.Remove(post);
            this.context.SaveChanges();
        }
    }
}
