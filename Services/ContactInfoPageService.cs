


namespace ContactInfo.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using ContactInfo.Application.Interfaces;
    using ContactInfo.Application.Models.Base;

    using ContactInfoWeb.Services;
    using ContactInfoWeb.ViewModels;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The contact info page service.
    /// </summary>
    public class ContactInfoPageService : IContactInfoPageService
    {
        /// <summary>
        /// The _contact app service.
        /// </summary>
        private readonly IContactInfoService _contactAppService;

        /// <summary>
        /// The _mapper.
        /// </summary>
        private readonly IMapper _mapper;

        private readonly ILogger<ContactInfoPageService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfoPageService"/> class.
        /// </summary>
        /// <param name="contactAppService">
        /// The _contact app service.
        /// </param>
        /// <param name="mapper">
        /// The mapper.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ContactInfoPageService(IContactInfoService contactAppService, IMapper mapper, ILogger<ContactInfoPageService> logger)
        {
            _contactAppService = contactAppService ?? throw new ArgumentNullException(nameof(contactAppService));
          
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// The get contact by id.
        /// </summary>
        /// <param name="contactId">
        /// The contact id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ContactInfoViewModel> GetContactById(int contactId)
        {
            var contact = await _contactAppService.GetContactById(contactId);
            var mapped = _mapper.Map<ContactInfoViewModel>(contact);
            return mapped;
        }

        /// <summary>
        /// The get contacts.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<ContactInfoViewModel>> GetContacts()
        {
           
            var list = await _contactAppService.GetContactList(); 
            var mapped = _mapper.Map<IEnumerable<ContactInfoViewModel>>(list);
            return mapped;
        }

        /// <summary>
        /// The create contact.
        /// </summary>
        /// <param name="contactInfoViewModel">
        /// The contact info view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ContactInfoViewModel> CreateContact(ContactInfoViewModel contactInfoViewModel)
        {
            var mapped = _mapper.Map<ContactInfoModel>(contactInfoViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            var entityDto = await _contactAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");

            var mappedViewModel = _mapper.Map<ContactInfoViewModel>(entityDto);
            return mappedViewModel;
        }

        /// <summary>
        /// The update contact.
        /// </summary>
        /// <param name="contactInfoViewModel">
        /// The contact info view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task UpdateContact(ContactInfoViewModel contactInfoViewModel)
        {
            var mapped = _mapper.Map<ContactInfoModel>(contactInfoViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _contactAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

        /// <summary>
        /// The delete contact.
        /// </summary>
        /// <param name="contactInfoViewModel">
        /// The contact info view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task DeleteContact(ContactInfoViewModel contactInfoViewModel)
        {
            var mapped = _mapper.Map<ContactInfoModel>(contactInfoViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _contactAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }
    }
}
