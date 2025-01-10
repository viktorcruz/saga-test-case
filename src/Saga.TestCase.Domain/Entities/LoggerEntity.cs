namespace Saga.TestCase.Domain.Entities
{
    public class LoggerEntity
    {
        public int IdLog { get; set; }
        public string IdCorrelation { get; set; }
        public string Environment { get; set; }
        public string LogLevel { get; set; }
        public string LoggerName { get; set; }
        public string ServerName { get; set; }
        public int LineNumber { get; set; }
        public string FileName { get; set; }
        public DateTime LogDate { get; set; }

        public LoggerEntity(int idLog, string idCorrelation, string environment, string logLevel, string loggerName, string serverName, int lineNumber, string fileName, DateTime logDate)
        {
            IdLog = idLog;
            IdCorrelation = idCorrelation;
            Environment = environment;
            LogLevel = logLevel;
            LoggerName = loggerName;
            ServerName = serverName;
            LineNumber = lineNumber;
            FileName = fileName;
            LogDate = logDate;
        }
    }
}
