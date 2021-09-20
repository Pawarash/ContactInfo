// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContactInfoService.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   The application exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ContactInfo.Application.Models.Base;

    /// <summary>
    /// The ContactInfoService interface.
    /// </summary>
    public interface IContactInfoService
    {
        /// <summary>
        /// The get contact list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IEnumerable<ContactInfoModel>> GetContactList();

        /// <summary>
        /// The get contact by id.
        /// </summary>
        /// <param name="contactId">
        /// The contact id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ContactInfoModel> GetContactById(int contactId);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ContactInfoModel> Create(ContactInfoModel contactInfoModel);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Update(ContactInfoModel contactInfoModel);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Delete(ContactInfoModel contactInfoModel);
    }
}
