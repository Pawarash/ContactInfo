// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Create.cshtml.cs" company="XYZ">
//  copyright 
// </copyright>
// <summary>
//   The create model.
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
    using Microsoft.AspNetCore.Mvc.Rendering;

    /// <summary>
    /// The create model.
    /// </summary>
    public class CreateModel : PageModel
    {
        /// <summary>
        /// The contact info page service.
        /// </summary>
        private readonly IContactInfoPageService contactInfoPageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateModel"/> class.
        /// </summary>
        /// <param name="icontactInfoPageService">
        /// The icontact info page service.
        /// </param>
        public CreateModel(IContactInfoPageService icontactInfoPageService)
        {
            contactInfoPageService = icontactInfoPageService ?? throw new ArgumentNullException(nameof(icontactInfoPageService));
        }

        /// <summary>
        /// The on get async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IActionResult> OnGetAsync()
        {
            var contact = await contactInfoPageService.GetContacts();
           // ViewData["ContactId"] = new SelectList(categories, "Id");
            return Page();
        }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        [BindProperty]
        public ContactInfoViewModel Contact { get; set; }

        /// <summary>
        /// The on post async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Contact.Status = true;
            Contact = await contactInfoPageService.CreateContact(Contact);
            return RedirectToPage("./Index");
        }
    }
}