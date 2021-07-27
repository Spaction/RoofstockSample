using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebEndpoint.Repository
{

    public class Repository<T, TContext> : IRepository<T> where T : class where TContext : DbContext
    {
        protected internal readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Partially adds an entity to the database. SaveChanges must be called before it is actually saved
        /// </summary>
        /// <param name="entity"></param>
        public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> Add(T entity)
        {
            return context.Set<T>().Attach(entity);
        }

        /// <summary>
        /// Partially adds a range entities to the database. SaveChanges must be called before it is actually saved
        /// </summary>
        /// <param name="entity"></param>
        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        /// <summary>
        /// Partially deltes an entity to the database. SaveChanges must be called before it is actually saved
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public Task<bool> ContainsAsync(T entity)
        {
            return context.Set<T>().ContainsAsync(entity);
        }

        public Task<T> FirstOrDefaultAsnyc(T entity)
        {
            return context.Set<T>().FirstOrDefaultAsync(y => y.Equals(entity));
        }
        public Task<List<T>> GetAll()
        {
            return context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
