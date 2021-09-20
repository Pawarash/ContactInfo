// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfrastructureException.cs" company="Xyz">
//  copyright 
// </copyright>
// <summary>
//   The infrastructure exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ContactInfo.Infrastructure.Exception
{
    using Exception = System.Exception;

    /// <summary>
    /// The infrastructure exception.
    /// </summary>
    public class InfrastructureException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureException"/> class.
        /// </summary>
        /// <param name="businessMessage">
        /// The business message.
        /// </param>
        internal InfrastructureException(string businessMessage)
            : base(businessMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        internal InfrastructureException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
