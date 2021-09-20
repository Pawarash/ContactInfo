// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreException.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   The core exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactInfo.Core.Exceptions
{
    using System;

    /// <summary>
    /// The core exception.
    /// </summary>
    public class CoreException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        /// <param name="businessMessage">
        /// The business message.
        /// </param>
        internal CoreException(string businessMessage)
            : base(businessMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        internal CoreException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
