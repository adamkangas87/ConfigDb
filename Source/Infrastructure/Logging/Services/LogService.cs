using Logging.Enums;
using Logging.Interfaces;
using Microsoft.Extensions.Logging;

namespace Logging.Services
{
    public class LogService<T> : ILogService<T> where T : class
    {
        private readonly ILogger<T> _logger;
        private readonly DateTimeOffset _currentDate = DateTimeOffset.Now;

        public LogService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }
        private string FormatMessage(string? message, ErrorTypes errorTypes = ErrorTypes.Info, params object?[] args)
        {
            string formatted = string.Format(message, args);
            string date = _currentDate.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ss");
            switch (errorTypes)
            {
                case ErrorTypes.Error:
                    formatted = "[ERROR] | " + date + " | " + formatted;
                    break;
                case ErrorTypes.Info:
                    formatted = "[INFO] | " + date + " | " + formatted;
                    break;
                case ErrorTypes.Debug:
                    formatted = "[DBUG] | " + date + " | " + formatted;
                    break;
                case ErrorTypes.Warning:
                    formatted = "[WARN] | " + date + " | " + formatted;
                    break;
            }
            return formatted;
        }

        public void LogDebug(string? message, params object?[] args)
        {
            _logger.LogDebug(FormatMessage(message, ErrorTypes.Debug, args));
        }

        public void LogDebug(Exception? exception, string? message, params object?[] args)
        {
            _logger.LogDebug(exception, FormatMessage(message, ErrorTypes.Debug, args));
        }

        public void LogError(Exception? exception, string? message, params object?[] args)
        {
            _logger.LogError(exception, FormatMessage(message, ErrorTypes.Error, args));
        }

        public void LogError(string? message, params object?[] args)
        {
            _logger.LogError(FormatMessage(message, ErrorTypes.Error, args));
        }

        public void LogInformation(string? message, params object?[] args)
        {
            _logger.LogInformation(FormatMessage(message, ErrorTypes.Info, args));
        }


        public void LogWarning(string? message, params object?[] args)
        {
            _logger.LogWarning(FormatMessage(message, ErrorTypes.Warning, args));
        }
    }

    public class LogService : ILogService
    {
        private readonly ILogger _logger;
        private readonly DateTimeOffset _currentDate = DateTimeOffset.Now;

        public LogService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("General");
        }
        private string FormatMessage(string? message, ErrorTypes errorTypes = ErrorTypes.Info, params object?[] args)
        {
            string formatted = string.Format(message, args);
            string date = _currentDate.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ss");
            switch (errorTypes)
            {
                case ErrorTypes.Error:
                    formatted = "[ERROR] | " + date + " | " + formatted;
                    break;
                case ErrorTypes.Info:
                    formatted = "[INFO] | " + date + " | " + formatted;
                    break;
                case ErrorTypes.Debug:
                    formatted = "[DBUG] | " + date + " | " + formatted;
                    break;
                case ErrorTypes.Warning:
                    formatted = "[WARN] | " + date + " | " + formatted;
                    break;
            }
            return formatted;
        }

        public void LogDebug(string? message, params object?[] args)
        {
            _logger.LogDebug(FormatMessage(message, ErrorTypes.Debug, args));
        }

        public void LogDebug(Exception? exception, string? message, params object?[] args)
        {
            _logger.LogDebug(exception, FormatMessage(message, ErrorTypes.Debug, args));
        }

        public void LogError(Exception? exception, string? message, params object?[] args)
        {
            _logger.LogError(exception, FormatMessage(message, ErrorTypes.Error, args));
        }

        public void LogError(string? message, params object?[] args)
        {
            _logger.LogError(FormatMessage(message, ErrorTypes.Error, args));
        }

        public void LogInformation(string? message, params object?[] args)
        {
            _logger.LogInformation(FormatMessage(message, ErrorTypes.Info, args));
        }


        public void LogWarning(string? message, params object?[] args)
        {
            _logger.LogWarning(FormatMessage(message, ErrorTypes.Warning, args));
        }
    }
}
