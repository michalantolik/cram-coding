﻿using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext context;

        public CommentRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public IQueryable<Comment> GetAll()
        {
            return this.context.Comment;
        }

        /// <inheritdoc/>
        public Comment Find(int id)
        {
            return this.context.Comment.Find(id);
        }

        /// <inheritdoc/>
        public void Add(Comment comment)
        {
            this.context.Comment.Add(comment);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Update(Comment comment)
        {
            this.context.Comment.Update(comment);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Comment comment)
        {
            this.context.Comment.Remove(comment);
            this.context.SaveChanges();
        }
    }
}
