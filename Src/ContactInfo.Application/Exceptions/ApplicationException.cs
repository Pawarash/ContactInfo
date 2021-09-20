// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationException.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   The application exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Application.Exceptions
{
    using System;

    /// <summary>
    /// The application exception.
    /// </summary>
    public class ApplicationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationException"/> class.
        /// </summary>
        /// <param name="businessMessage">
        /// The business message.
        /// </param>
        internal ApplicationException(string businessMessage)
            : base(businessMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        internal ApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
