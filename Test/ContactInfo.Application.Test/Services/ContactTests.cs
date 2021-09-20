// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactTests.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   Defines the ContactTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ContactInfo.Application.Test.Services
{
    using System;
    using System.Threading.Tasks;

    using ContactInfo.Application.Models.Base;
    using ContactInfo.Application.Services;
    using ContactInfo.Core.Entities;
    using ContactInfo.Core.Interfaces;
    using ContactInfo.Core.Repositories;
    using ContactInfo.Core.Repositories.Base;

    using Moq;

    using Xunit;

    /// <summary>
    /// The contact tests.
    /// </summary>
    public class ContactTests
    {
        // NOTE : This layer we are not loaded database objects, test functionality of application layer

        /// <summary>
        /// The _mock contact info repository.
        /// </summary>
        private Mock<IContactInfoRepository> _mockContactInfoRepository;

        /// <summary>
        /// The _mock contact repository.
        /// </summary>
        private Mock<IRepository<Contact>> _mockContactRepository;

        /// <summary>
        /// The _mock app logger.
        /// </summary>
        private Mock<IAppLogger<ContactInfoService>> _mockAppLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactTests"/> class.
        /// </summary>
        public ContactTests()
        {
            _mockContactInfoRepository = new Mock<IContactInfoRepository>();
            _mockContactRepository = new Mock<IRepository<Contact>>();
            _mockAppLogger = new Mock<IAppLogger<ContactInfoService>>();
        }

        /// <summary>
        /// The get_ contact_ list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Fact]
        public async Task Get_Contact_List()    
        {
            var contact = Contact.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>());
            var contact1 = Contact.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>());
            var contact2 = Contact.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>());



            _mockContactInfoRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(contact);
            _mockContactInfoRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(contact1);

            var contactInfoService = new ContactInfoService(_mockContactInfoRepository.Object, _mockAppLogger.Object);
            var contactList = await contactInfoService.GetContactList();

            _mockContactInfoRepository.Verify(x => x.GetContactListAsync(), Times.Once);
        }

        /// <summary>
        /// The create_ new_ contact.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Fact]
        public async Task Create_New_Contact()
        {
            var contact = Contact.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>());


            _mockContactInfoRepository.Setup(x => x.AddAsync(contact)).ReturnsAsync(contact);

            var contactInfoService = new ContactInfoService(_mockContactInfoRepository.Object, _mockAppLogger.Object);
            var createdContacttDto = await contactInfoService.Create(new ContactInfoModel {Id = contact.Id, FirstName = contact.FirstName, LastName = contact.LastName, Email = contact.Email, Status = contact.Status });
           
            _mockContactInfoRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _mockContactInfoRepository.Verify(x => x.AddAsync(It.IsAny<Contact>()), Times.Once);
        }

        [Fact]
        public async Task Create_New_Contact_Validate_If_Exist()
        {
            var contact = Contact.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>());


            _mockContactInfoRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(contact);
            _mockContactInfoRepository.Setup(x => x.AddAsync(contact)).ReturnsAsync(contact);

            var contactInfoService = new ContactInfoService(_mockContactInfoRepository.Object, _mockAppLogger.Object);

            await Assert.ThrowsAsync<ApplicationException>(async () =>
                await contactInfoService.Create(new ContactInfoModel { FirstName = contact.FirstName, LastName = contact.LastName, Email = contact.Email, Status = contact.Status }));
        }
    }
}
