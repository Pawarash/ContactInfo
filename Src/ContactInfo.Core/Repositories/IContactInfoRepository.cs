// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContactInfoRepository.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   The ContactInfoRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Core.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ContactInfo.Core.Entities;
    using ContactInfo.Core.Repositories.Base;

    /// <summary>
    /// The ContactInfoRepository interface.
    /// </summary>
    public interface IContactInfoRepository : IRepository<Contact>
    {
        /// <summary>
        /// The get contact list async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IEnumerable<Contact>> GetContactListAsync();
    }
}
