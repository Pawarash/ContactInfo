// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Index.cshtml.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   Defines the IndexModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfoWeb.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ContactInfoWeb.Interfaces;
    using ContactInfoWeb.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// The index model.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly IIndexPageService _iIndexPageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="indexPageService">
        /// The index page service.
        /// </param>
        public IndexModel(IIndexPageService indexPageService)
        {
            _iIndexPageService = indexPageService ?? throw new ArgumentNullException(nameof(indexPageService));
        }

        /// <summary>
        /// Gets or sets the contact list.
        /// </summary>
        public IEnumerable<ContactInfoViewModel> ContactList { get; set; } = new List<ContactInfoViewModel>();

        /// <summary>
        /// Gets or sets the contact info view model.
        /// </summary>
        public ContactInfoViewModel ContactInfoViewModel { get; set; } = new ContactInfoViewModel();

        /// <summary>
        /// The on get.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IActionResult> OnGet()
        {
            ContactList = await _iIndexPageService.GetContacts();
            return Page();
        }
    }
}
