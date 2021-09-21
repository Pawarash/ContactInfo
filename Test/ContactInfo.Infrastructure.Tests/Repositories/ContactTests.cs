// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactTests.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   Defines the ContactTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Infrastructure.Tests.Repositories
{
    using System.Threading.Tasks;

    using ContactInfo.Infrastructure.Data;
    using ContactInfo.Infrastructure.Repository;
    using ContactInfo.Infrastructure.Tests.Builders;

    using Microsoft.EntityFrameworkCore;

    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// The contact tests.
    /// </summary>
    public  class ContactTests
    {
        /// <summary>
        /// The _contact info context.
        /// </summary>
        private readonly ContactInfoContext _contactInfoContext;

        /// <summary>
        /// The _contact info repository.
        /// </summary>
        private readonly ContactInfoRepository _contactInfoRepository;

        /// <summary>
        /// The _output.
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Gets the contact builder.
        /// </summary>
        private ContactBuilder contactBuilder { get; } = new ContactBuilder();

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public ContactTests(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<ContactInfoContext>()
                .UseInMemoryDatabase(databaseName: "ContactInfo")
                .Options;
            _contactInfoContext = new ContactInfoContext(dbOptions);
            _contactInfoRepository = new ContactInfoRepository(_contactInfoContext);
        }

        [Fact]
        public async Task Get_Existing_Contact()
        {
            var existingContact = contactBuilder.WithDefaultValues();
            _contactInfoContext.Contacts.Add(existingContact);
            _contactInfoContext.SaveChanges();

            var contactId = existingContact.Id;
            _output.WriteLine($"ContactId: {contactId}");

            var contactFromRepo = await _contactInfoRepository.GetByIdAsync(contactId);

            Assert.Equal(contactBuilder.TestContactId, contactFromRepo.Id);
            Assert.Equal(contactBuilder.TestContactFirstName, contactFromRepo.FirstName);
            Assert.Equal(contactBuilder.TestContactLastName, contactFromRepo.LastName);
            Assert.Equal(contactBuilder.TestContactEmail, contactFromRepo.Email);
            Assert.Equal(contactBuilder.TestContactPhoneNumber, contactFromRepo.PhoneNumber);
            Assert.Equal(contactBuilder.TestContactStatus, contactFromRepo.Status);
        }
    }
}
