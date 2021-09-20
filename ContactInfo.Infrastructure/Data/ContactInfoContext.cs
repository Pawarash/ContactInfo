// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactInfoContext.cs" company="Xyz">
// copyright  
// </copyright>
// <summary>
//   The contact info context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Infrastructure.Data
{
    using ContactInfo.Core.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The contact info context.
    /// </summary>
    public class ContactInfoContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfoContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        public ContactInfoContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>(ConfigureContact);
        }

        /// <summary>
        /// The configure contact.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        private void ConfigureContact(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cb => cb.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cb => cb.Email)
                .IsRequired()
                .HasMaxLength(50);
            }
        }
}
