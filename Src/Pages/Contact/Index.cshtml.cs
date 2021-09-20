// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Index.cshtml.cs" company="Xyz">
// copyright  
// </copyright>
// <summary>
//   Defines the IndexModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfoWeb.Pages.Contact
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ContactInfoWeb.Services;
    using ContactInfoWeb.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// The index model.
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The _i contact info page service.
        /// </summary>
        private readonly IContactInfoPageService _iContactInfoPageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="iContactInfoPageService">
        /// The i contact info page service.
        /// </param>
        public IndexModel(IContactInfoPageService iContactInfoPageService)
        {
            _iContactInfoPageService = iContactInfoPageService ?? throw new ArgumentNullException(nameof(iContactInfoPageService));
        }

        /// <summary>
        /// Gets or sets the contact list.
        /// </summary>
        public IEnumerable<ContactInfoViewModel> ContactList { get; set; } = new List<ContactInfoViewModel>();

        /// <summary>
        /// The on get async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IActionResult> OnGetAsync()
        {
            ContactList = await _iContactInfoPageService.GetContacts();
            return Page();
        }
    }
}
