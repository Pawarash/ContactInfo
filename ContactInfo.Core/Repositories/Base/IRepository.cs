// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   Defines the IRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Core.Repositories.Base
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ContactInfo.Core.Entities.Base;

    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// The get all async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// The add async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task DeleteAsync(T entity);
       
    }
}
