// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactInfoService.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   The contact info service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
   
    using ContactInfo.Application.Interfaces;
    using ContactInfo.Application.Mapper;
    using ContactInfo.Application.Models.Base;
    using ContactInfo.Core.Entities;
    using ContactInfo.Core.Interfaces;
    using ContactInfo.Core.Repositories;

    /// <summary>
    /// The contact info service.
    /// </summary>
    public class ContactInfoService : IContactInfoService
    {
        /// <summary>
        /// The _i contact info repository.
        /// </summary>
        private readonly IContactInfoRepository _contactInfoRepository;

        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly IAppLogger<ContactInfoService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfoService"/> class.
        /// </summary>
        /// <param name="iContactInfoRepository">
        /// The i contact info repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ContactInfoService(IContactInfoRepository contactInfoRepository, IAppLogger<ContactInfoService> logger)
        {
            _contactInfoRepository = contactInfoRepository ?? throw new ArgumentNullException(nameof(contactInfoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// The get contact list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<ContactInfoModel>> GetContactList()
        {
            var contactInfoList = await _contactInfoRepository.GetContactListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ContactInfoModel>>(contactInfoList);
            return mapped;
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
        public async Task<ContactInfoModel> GetContactById(int contactId)
        {
            var contactInfo = await _contactInfoRepository.GetByIdAsync(contactId);
            var mapped = ObjectMapper.Mapper.Map<ContactInfoModel>(contactInfo);
            return mapped;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        public async Task<ContactInfoModel> Create(ContactInfoModel contactInfoModel)
        {
            await ValidateContactIfExist(contactInfoModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Contact>(contactInfoModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _contactInfoRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ContactInfoModel>(newEntity);
            return newMappedEntity;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        public async Task Update(ContactInfoModel contactInfoModel)
        {
            ValidateContactIfNotExist(contactInfoModel);

            var editContact = await _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (editContact == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<ContactInfoModel, Contact>(contactInfoModel, editContact);

            await _contactInfoRepository.UpdateAsync(editContact);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        public async Task Delete(ContactInfoModel contactInfoModel)
        {
            ValidateContactIfNotExist(contactInfoModel);
            var deletedContact = await _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (deletedContact == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _contactInfoRepository.DeleteAsync(deletedContact);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        /// <summary>
        /// The validate contact if exist.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        private async Task ValidateContactIfExist(ContactInfoModel contactInfoModel)
        {
            var existingEntity = await _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{contactInfoModel.ToString()} with this id already exists");
        }

        /// <summary>
        /// The validate contact if not exist.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <exception cref="ApplicationException">
        /// </exception>
        private void ValidateContactIfNotExist(ContactInfoModel contactInfoModel)
        {
            var existingEntity = _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{contactInfoModel.ToString()} with this id is not exists");
        }
    }
}
