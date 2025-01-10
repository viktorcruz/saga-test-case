namespace Saga.TestCase.Application.Logger.Queries.Dto
{
    public class LoggerResponseDTO
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
    }
}
