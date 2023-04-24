using System;

namespace Logging.Interfaces
{
    public interface ILogService<T>
    {
        void LogInformation(string? message, params object?[] args);

        void LogError(Exception? exception, string? message, params object?[] args);
        void LogError(string? message, params object?[] args);

        void LogWarning(string? message, params object?[] args);

        void LogDebug(string? message, params object?[] args);
        void LogDebug(Exception? exception, string? message, params object?[] args);
    }
    public interface ILogService
    {
        void LogInformation(string? message, params object?[] args);

        void LogError(Exception? exception, string? message, params object?[] args);
        void LogError(string? message, params object?[] args);

        void LogWarning(string? message, params object?[] args);

        void LogDebug(string? message, params object?[] args);
        void LogDebug(Exception? exception, string? message, params object?[] args);
    }
}
