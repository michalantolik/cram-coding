using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CramCoding.Data.Repositories
{
    /// <summary>
    /// Base generic repository class
    /// </summary>
    /// <typeparam name="TEntity">Type of entity to be managed</typeparam>
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <inheritdoc/>
        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public TEntity FindById(int id)
        {
            return this.dbSet.Find(id);
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> GetAll()
        {
            return this.dbSet.AsQueryable();
        }

        /// <inheritdoc/>
        public void Update(TEntity entity)
        {
            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
    }
}
