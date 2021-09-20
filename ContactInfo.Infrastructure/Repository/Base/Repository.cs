// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   Defines the Repository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace ContactInfo.Infrastructure.Repository.Base
{
    using System;
    using System.Collections.Generic;
 
    using System.Threading.Tasks;

    using ContactInfo.Core.Entities.Base;
    using ContactInfo.Core.Repositories.Base;
  
    using ContactInfo.Infrastructure.Data;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class Repository<T> : IRepository<T> where T : Entity
    {
        /// <summary>
        /// The _db context.
        /// </summary>
        protected readonly ContactInfoContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public Repository(ContactInfoContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// The get all async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
       

        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// The add async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
