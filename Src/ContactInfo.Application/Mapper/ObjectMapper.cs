// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectMapper.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   The object mapper.
//   The Mapper
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Application.Mapper
{
    using System;
    using AutoMapper;

    /// <summary>
    /// The object mapper.
    /// The Mapper
    /// </summary>
    public static class ObjectMapper
        {
            /// <summary>
            /// The lazy.
            /// </summary>
            private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
                {
                    var config = new MapperConfiguration(cfg =>
                        {
                            // This line ensures that internal properties are also mapped over.
                            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                            cfg.AddProfile<ContactInfoDtoMapper>();
                        });
                    var mapper = config.CreateMapper();
                    return mapper;
                });

            /// <summary>
            /// The mapper.
            /// </summary>
            public static IMapper Mapper => Lazy.Value;
        }
}
