using System.Net;

namespace NamesAndTablesApi.Middlewares;

public static class ExceptionLogging
{
    internal static void LogExceptionWarning(ILogger<ExceptionMiddleware> logger, HttpStatusCode exceptionCode, Exception exception, string exceptionName)
    {
        var definedWarningMessage = LoggerMessage.Define(LogLevel.Warning, new EventId(1, exceptionName),
           $"\nHandle {exceptionName} {exceptionCode}: {exceptionCode}\n\nMessage: '{exception.Message}'");

        definedWarningMessage(logger, null);
    }

    internal static void LogExceptionError(ILogger<ExceptionMiddleware> logger, HttpStatusCode exceptionCode, Exception exception, string exceptionName)
    {
        {
            var definedErrorMessage = LoggerMessage.Define(LogLevel.Error, new EventId(2, exceptionName),
                $"\nHandle {exceptionName} {exceptionCode}: {exceptionCode}\n\nMessage: '{exception.Message}'\n\nInnerException: '{exception.StackTrace}'");

            definedErrorMessage(logger, null);
        }
    }
}