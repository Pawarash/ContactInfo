

namespace ContactInfo.Infrastructure.Logging
{
    using ContactInfo.Core.Interfaces;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The logger adapter.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly ILogger<T> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerAdapter{T}"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The logger factory.
        /// </param>
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        /// <summary>
        /// The log warning.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        /// <summary>
        /// The log information.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }
    }
}
