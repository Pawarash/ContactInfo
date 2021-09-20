// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Details.cshtml.cs" company="Xyz">
//  copyright
// </copyright>
// <summary>
//   The details model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfoWeb.Pages.Contact
{
    using System;
    using System.Threading.Tasks;

    using ContactInfoWeb.Services;
    using ContactInfoWeb.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// The details model.
    /// </summary>
    public class DetailsModel : PageModel
    {
        /// <summary>
        /// The _i contact info page service.
        /// </summary>
        private readonly IContactInfoPageService _iContactInfoPageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailsModel"/> class.
        /// </summary>
        /// <param name="iContactInfoPageService">
        /// The i contact info page service.
        /// </param>
        public DetailsModel(IContactInfoPageService iContactInfoPageService)
        {
            _iContactInfoPageService = iContactInfoPageService ?? throw new ArgumentNullException(nameof(iContactInfoPageService));
        }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        public ContactInfoViewModel Contact { get; set; }

        /// <summary>
        /// The on get async.
        /// </summary>
        /// <param name="contactId">
        /// The contact id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IActionResult> OnGetAsync(int? contactId)
        {
            if (contactId == null)
            {
                return NotFound();
            }

            Contact = await _iContactInfoPageService.GetContactById(contactId.Value);

            if (Contact == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
