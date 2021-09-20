// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIndexPageService.cs" company="Xyz">
// copyright   
// </copyright>
// <summary>
//   The IndexPageService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfoWeb.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ContactInfoWeb.ViewModels;

    // NOTE : This is the whole page service, it could be include all Contacts
    // this is the razor page based service

    /// <summary>
    /// The IndexPageService interface.
    /// </summary>
    public interface IIndexPageService
    {
        /// <summary>
        /// The get contacts.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IEnumerable<ContactInfoViewModel>> GetContacts();        
    }
}
