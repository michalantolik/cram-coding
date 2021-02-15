using CramCoding.WebApp.Models.EntityClasses;
using System.Linq;

namespace CramCoding.WebApp.Models.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext context;

        public CommentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Comment> GetAll()
        {
            return this.context.Comment;
        }

        public Comment Find(int id)
        {
            return this.context.Comment.Find(id);
        }

        public void Add(Comment comment)
        {
            this.context.Comment.Add(comment);
            this.context.SaveChanges();
        }

        public void Update(Comment comment)
        {
            this.context.Comment.Update(comment);
            this.context.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            this.context.Comment.Remove(comment);
            this.context.SaveChanges();
        }
    }
}
