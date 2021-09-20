// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactPageTests.cs" company="Xyz">
//  copyright 
// </copyright>
// <summary>
//   The contact page tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ContactInfo.Web.Tests.Pages
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using ContactInfoWeb;

    using Xunit;

    /// <summary>
    /// The contact page tests.
    /// </summary>
    public class ContactPageTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        /// <summary>
        /// Gets the client.
        /// </summary>
        public HttpClient Client { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactPageTests"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        public ContactPageTests(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        /// <summary>
        /// The contact_ page_ test.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Fact]
        public async Task Contact_Page_Test()
        {
            // Arrange & Act
            var response = await Client.GetAsync("/Contact/Index");
            response.EnsureSuccessStatusCode();

            // Assert

           Assert.True(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
