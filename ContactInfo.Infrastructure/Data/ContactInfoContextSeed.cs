// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactInfoContextSeed.cs" company="Xyz">
// copyright  
// </copyright>
// <summary>
//   Defines the ContactInfoContextSeed type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Infrastructure.Data
{
    using System.Collections.Generic;

    using System.Threading.Tasks;

    using ContactInfo.Core.Entities;

    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.Extensions.Logging;

    using Exception = System.Exception;

    /// <summary>
    /// The contact info context seed.
    /// </summary>
    public class ContactInfoContextSeed
    {
        /// <summary>
        /// The seed async.
        /// </summary>
        /// <param name="contactInfoContext">
        /// The contact info context.
        /// </param>
        /// <param name="loggerFactory">
        /// The logger factory.
        /// </param>
        /// <param name="retry">
        /// The retry.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task SeedAsync(ContactInfoContext contactInfoContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            if (retry != null)
            {
                int retryForAvailability = retry.Value;

                try
                {
                    if (!contactInfoContext.Contacts.Any())
                    {
                        contactInfoContext.Contacts.AddRange(GetPreconfiguredContacts());
                        await contactInfoContext.SaveChangesAsync();
                    }
                }
                catch (Exception exception)
                {
                    if (retryForAvailability < 10)
                    {
                        retryForAvailability++;
                        var log = loggerFactory.CreateLogger<ContactInfoContextSeed>();
                        log.LogError(exception.Message);
                        await SeedAsync(contactInfoContext, loggerFactory, retryForAvailability);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// The get preconfigured contacts.
        /// </summary>
        /// <returns>
        /// The <see cref="Contact"/>.
        /// </returns>
        private static IEnumerable<Contact> GetPreconfiguredContacts()
        {
            return new List<Contact>()
            {
                new Contact() { FirstName = "John", LastName = "Sinha", Email = "xyz@gmail.com", PhoneNumber = "00000", Status = true },
                new Contact() { FirstName = "Spider", LastName = "Man", Email = "pqr@gmail.com", PhoneNumber = "00000", Status = true },
                new Contact() { FirstName = "Iron", LastName = "Man", Email = "fcv@gmail.com", PhoneNumber = "00000", Status = true }
            };
        }
    }
}
