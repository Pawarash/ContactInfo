// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndexPageHealthCheck.cs" company="Xyz">
//  copyright
// </copyright>
// <summary>
//   Defines the IndexPageHealthCheck type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ContactInfoWeb.HealthChecks
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Diagnostics.HealthChecks;

    /// <summary>
    /// The index page health check.
    /// </summary>
    public class IndexPageHealthCheck : IHealthCheck
    {
        /// <summary>
        /// The _http context accessor.
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexPageHealthCheck"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">
        /// The http context accessor.
        /// </param>
        public IndexPageHealthCheck(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// The check health async.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = _httpContextAccessor.HttpContext.Request;
            string myUrl = request.Scheme + "://" + request.Host.ToString();

            var client = new HttpClient();
            var response = await client.GetAsync(myUrl);
            var pageContents = await response.Content.ReadAsStringAsync();
            if (pageContents.Contains("contact1"))
            {
                return HealthCheckResult.Healthy("The check indicates a healthy result.");
            }

            return HealthCheckResult.Unhealthy("The check indicates an unhealthy result.");
        }
    }
}
