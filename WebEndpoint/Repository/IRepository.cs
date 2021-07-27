using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebEndpoint.Repository
{
    
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAll();

        /// Partially adds an entity to the database. SaveChanges must be called before it is actually saved
        /// </summary>
        /// <param name="entity"></param>
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> Add(T entity);

        /// <summary>
        /// Partially adds a range entities to the database. SaveChanges must be called before it is actually saved
        /// </summary>
        /// <param name="entity"></param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Partially deltes an entity to the database. SaveChanges must be called before it is actually saved
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        Task<T> FirstOrDefaultAsnyc(T entity);

        Task<bool> ContainsAsync(T entity);

        Task<T> GetById(int id);
    }
}
