// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactInfoViewModel.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   The contact info view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfoWeb.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The contact info view model.
    /// </summary>
    public class ContactInfoViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required(ErrorMessage = "First Name is Required")]
        [MinLength(3, ErrorMessage = "First Name should contained at least three characters")]
        [RegularExpression(@"^[a-zA-Z0]+$", ErrorMessage = "InValid First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required(ErrorMessage = "Last Name is Required")]
        [MinLength(3, ErrorMessage = "Last Name should contained at least three characters")]
        [RegularExpression(@"^[a-zA-Z0]+$", ErrorMessage = "InValid First Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-zA-Z0-9-+.]+$", ErrorMessage = "InValid Email format")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [MaxLength(10, ErrorMessage = "Phone Number should not have more than 10 digits")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether status.
        /// </summary>
        public bool Status { get; set; }
    }
}
