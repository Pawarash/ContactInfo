// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactInfoDtoMapper.cs" company="xyz">
//   copyright
// </copyright>
// <summary>
//   The contact info dto mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Application.Mapper
{
    using AutoMapper;

    using ContactInfo.Application.Models.Base;
    using ContactInfo.Core.Entities;

    /// <summary>
    /// The contact info dto mapper.
    /// </summary>
    public class ContactInfoDtoMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfoDtoMapper"/> class.
        /// </summary>
        public ContactInfoDtoMapper()
        {
            CreateMap<Contact, ContactInfoModel>().ReverseMap();
        }
    }
}
