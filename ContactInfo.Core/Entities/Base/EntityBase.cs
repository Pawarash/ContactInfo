// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   Defines the EntityBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Core.Entities.Base
{
    /// <summary>
    /// The entity base.
    /// </summary>
    /// <typeparam name="TId">
    /// </typeparam>
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public virtual TId Id { get; protected set; }
    }
}
