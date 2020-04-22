using NLog;

namespace infosecSoft.infosecPDF.Shared.Helper.Logging
{
    internal interface ILogger
    {
        void ChangeLogLevel(LogLevel logLevel);

        string GetLogPath();
    }
}