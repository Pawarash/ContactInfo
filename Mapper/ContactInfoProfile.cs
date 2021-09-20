// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactInfoProfile.cs" company="Xyz">
//  copyright 
// </copyright>
// <summary>
//   The contact info profile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfoWeb.Mapper
{
    using AutoMapper;
    using ContactInfo.Application.Models.Base;
    using ContactInfoWeb.ViewModels;

    /// <summary>
    /// The contact info profile.
    /// </summary>
    public class ContactInfoProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfoProfile"/> class.
        /// </summary>
        public ContactInfoProfile()
        {
            CreateMap<ContactInfoModel, ContactInfoViewModel>().ReverseMap();
        }
    }
}
