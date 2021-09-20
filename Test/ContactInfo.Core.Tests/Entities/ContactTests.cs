// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactTests.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   The contact tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ContactInfo.Core.Tests.Entities
{
    using ContactInfo.Core.Entities;

    using Xunit;

    /// <summary>
    /// The contact tests.
    /// </summary>
    public class ContactTests
    {
        /// <summary>
        /// The _contact id.
        /// </summary>
        private int _contactId = 1;

        /// <summary>
        /// The _first name.
        /// </summary>
        private string _firstName = "TestFName";

        /// <summary>
        /// The _last name.
        /// </summary>
        private string _lastName = "TestLName";

        /// <summary>
        /// The _email.
        /// </summary>
        private string _email = "TestEmail";

        /// <summary>
        /// The _phone number.
        /// </summary>
        private string _phoneNumber = "0123456789";

        /// <summary>
        /// The _status.
        /// </summary>
        private bool _status = true;

        /// <summary>
        /// The create_ contact.
        /// </summary>
        [Fact]
        public void Create_Contact()
        {
            var contact = Contact.Create(_contactId, _firstName, _lastName, _email, _phoneNumber, _status);

            Assert.Equal(_contactId, contact.Id);
            Assert.Equal(_firstName, contact.FirstName);
            Assert.Equal(_lastName, contact.LastName);
            Assert.Equal(_email, contact.Email);
            Assert.Equal(_phoneNumber, contact.PhoneNumber);
            Assert.Equal(_status, contact.Status);
        }
    }
}
