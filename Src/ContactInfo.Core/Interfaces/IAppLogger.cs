// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAppLogger.cs" company="Xyz">
//   copyright
// </copyright>
// <summary>
//   Defines the IAppLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace ContactInfo.Core.Interfaces
{
    /// <summary>
    /// The AppLogger interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IAppLogger<T>
    {
        /// <summary>
        /// The log information.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        void LogInformation(string message, params object[] args);

        /// <summary>
        /// The log warning.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        void LogWarning(string message, params object[] args);
    }
}
