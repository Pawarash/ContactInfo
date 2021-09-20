// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactInfoModel.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   Defines the ContactInfoModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ContactInfo.Application.Models.Base
{
    /// <summary>
    /// The contact info model.
    /// </summary>
    public class ContactInfoModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether status.
        /// </summary>
        public bool Status { get; set; }
    }
}
