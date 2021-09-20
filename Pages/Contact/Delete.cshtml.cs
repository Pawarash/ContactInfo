// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Delete.cshtml.cs" company="Xyz">
//  copyright 
// </copyright>
// <summary>
//   Defines the DeleteModel type.
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
    /// The delete model.
    /// </summary>
    public class DeleteModel : PageModel
    {
        /// <summary>
        /// The _i contact info page service.
        /// </summary>
        private readonly IContactInfoPageService _iContactInfoPageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteModel"/> class.
        /// </summary>
        /// <param name="iContactInfoPageService">
        /// The i contact info page service.
        /// </param>
        public DeleteModel(IContactInfoPageService iContactInfoPageService)
        {
            _iContactInfoPageService = iContactInfoPageService ?? throw new ArgumentNullException(nameof(iContactInfoPageService));
        }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        [BindProperty]
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

        /// <summary>
        /// The on post async.
        /// </summary>
        /// <param name="contactId">
        /// The contact id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IActionResult> OnPostAsync(int? contactId)
        {
            if (contactId == null)
            {
                return NotFound();
            }

            await _iContactInfoPageService.DeleteContact(Contact);          
            return RedirectToPage("./Index");
        }
    }
}
