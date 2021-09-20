// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndexPageService.cs" company="Xyz">
// copyright  
// </copyright>
// <summary>
//   The index page service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfoWeb.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using ContactInfo.Application.Interfaces;

    using ContactInfoWeb.Interfaces;
    using ContactInfoWeb.ViewModels;

    /// <summary>
    /// The index page service.
    /// </summary>
    public class IndexPageService : IIndexPageService
    {
        /// <summary>
        /// The _contact app service.
        /// </summary>
        private readonly IContactInfoService _contactAppService;

        /// <summary>
        /// The _mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexPageService"/> class.
        /// </summary>
        /// <param name="contactInfoAppService">
        /// The contact info app service.
        /// </param>
        /// <param name="mapper">
        /// The mapper.
        /// </param>
        public IndexPageService(IContactInfoService contactInfoAppService, IMapper mapper)
        {
            _contactAppService = contactInfoAppService ?? throw new ArgumentNullException(nameof(contactInfoAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
    }
}
