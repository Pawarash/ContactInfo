// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactBuilder.cs" company="Xyz">
//  copyright 
// </copyright>
// <summary>
//   Defines the ContactBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace ContactInfo.Infrastructure.Tests.Builders
{
    using ContactInfo.Core.Entities;

    /// <summary>
    /// The contact builder.
    /// </summary>
    public class ContactBuilder
    {
        /// <summary>
        /// The _contact.
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// The test contact id.
        /// </summary>
        public int TestContactId = 1;

        /// <summary>
        /// The test contact first name.
        /// </summary>
        public string TestContactFirstName => "TestContactFirstName";

        /// <summary>
        /// The test contact last name.
        /// </summary>
        public string TestContactLastName => "TestContactLastName";

        /// <summary>
        /// The test contact email.
        /// </summary>
        public string TestContactEmail => "TestContactEmail";

        /// <summary>
        /// The test contact phone number.
        /// </summary>
        public string TestContactPhoneNumber => "1234567890";

        /// <summary>
        /// The test contact status.
        /// </summary>
        public bool TestContactStatus => true;

        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="Contact"/>.
        /// </returns>
        public Contact Build()
        {
            return _contact;
        }

        public Contact WithDefaultValues()
        {
            return  Contact.Create(TestContactId, TestContactFirstName, TestContactLastName, TestContactEmail, TestContactPhoneNumber, TestContactStatus);
        }
    }
}
