// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndexPageTest.cs" company="Xyz">
//  copyright
// </copyright>
// <summary>
//   Defines the IndexPageTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace ContactInfo.Web.Tests.Pages
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using ContactInfoWeb;

    using Xunit;

    /// <summary>
    /// The index page test.
    /// </summary>
    public class IndexPageTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        /// <summary>
        /// Gets the client.
        /// </summary>
        public HttpClient Client { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexPageTest"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        public IndexPageTest(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        /// <summary>
        /// The index_ page_ test.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Fact]
        public async Task Index_Page_Test()
        {
            // Arrange & Act
            var response = await Client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("ContactInfo", stringResponse);
        }
    }
}
