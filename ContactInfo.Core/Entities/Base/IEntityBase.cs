// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityBase.cs" company="Xyz">
// copyright
// </copyright>
// <summary>
//   Defines the IEntityBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Core.Entities.Base
{
    /// <summary>
    /// The EntityBase interface.
    /// </summary>
    /// <typeparam name="TId">
    /// </typeparam>
    public interface IEntityBase<TId>
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        TId Id { get; }
    }
}
