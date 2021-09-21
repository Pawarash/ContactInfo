// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="Xyz">
// copyright  
// </copyright>
// <summary>
//   Defines the Contact type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ContactInfo.Core.Entities
{
    using ContactInfo.Core.Entities.Base;

    /// <summary>
    /// The contact.
    /// </summary>
    public class Contact : Entity
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

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="phoneNumber">
        /// The phone number.
        /// </param>
        ///  /// <param name="status">
        /// The status.
        /// </param>
        /// <returns>
        /// The <see cref="Contact"/>.
        /// </returns>
        public static Contact Create(int contactId, string firstName, string lastName, string email, string phoneNumber, bool status)
        {
            var contact = new Contact
            {    
                 Id = contactId,
                 FirstName = firstName,
                 LastName = lastName,
                 Email = email,
                 PhoneNumber = phoneNumber,
                 Status = status
            };
            return contact;
        }
    }
}
