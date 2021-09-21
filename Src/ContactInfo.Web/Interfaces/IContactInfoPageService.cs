// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContactInfoPageService.cs" company="Xyz">
//  copyright 
// </copyright>
// <summary>
//   The ContactInfoPageService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfoWeb.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ContactInfoWeb.ViewModels;

    /// <summary>
    /// The ContactInfoPageService interface.
    /// </summary>
    public interface IContactInfoPageService
    {
        /// <summary>
        /// The get contact by id.
        /// </summary>
        /// <param name="contactId">
        /// The contact id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ContactInfoViewModel> GetContactById(int contactId);

        /// <summary>
        /// The get contacts.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IEnumerable<ContactInfoViewModel>> GetContacts();

        /// <summary>
        /// The create contact.
        /// </summary>
        /// <param name="contactInfoViewModel">
        /// The contact info view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ContactInfoViewModel> CreateContact(ContactInfoViewModel contactInfoViewModel);

        /// <summary>
        /// The update contact.
        /// </summary>
        /// <param name="contactInfoViewModel">
        /// The contact info view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task UpdateContact(ContactInfoViewModel contactInfoViewModel);

        /// <summary>
        /// The delete contact.
        /// </summary>
        /// <param name="contactInfoViewModel">
        /// The contact info view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task DeleteContact(ContactInfoViewModel contactInfoViewModel);
    }
}