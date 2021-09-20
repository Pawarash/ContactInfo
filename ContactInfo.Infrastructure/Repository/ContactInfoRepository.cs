// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactInfoRepository.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   The contact info repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ContactInfo.Infrastructure.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ContactInfo.Core.Entities;
    using ContactInfo.Core.Repositories;
    using ContactInfo.Infrastructure.Data;
    using ContactInfo.Infrastructure.Repository.Base;

    /// <summary>
    /// The contact info repository.
    /// </summary>
    public class ContactInfoRepository : Repository<Contact>, IContactInfoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfoRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public ContactInfoRepository(ContactInfoContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// The get contact list async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<Contact>> GetContactListAsync()
        {

            // second way
             return await GetAllAsync();
        }
    }
}
