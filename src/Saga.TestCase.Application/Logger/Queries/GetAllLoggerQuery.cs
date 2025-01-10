using MediatR;
using Saga.TestCase.Application.Logger.Queries.Dto;

namespace Saga.TestCase.Application.Core.Queries
{
    public class GetAllLoggerQuery : IRequest<List<LoggerResponseDTO>>
    {
        #region Properties
        public string TipoRepositorio { get; set; }
        #endregion

        //#region Properties
        //public int IdLog { get; set; }
        //public string IdCorrelation { get; set; }
        //public string Environment { get; set; }
        //public string LogLevel { get; set; }
        //public string LoggerName { get; set; }
        //public string ServerName { get; set; }
        //public int LineNumber { get; set; }
        //public string FileName { get; set; }
        //public DateTime LogDate { get; set; }
        //#endregion

        //#region COnstructor
        //public GetAllLoggerQuery(LoggerResponseDTO dto)
        //{
        //    IdLog = dto.IdLog;
        //    IdCorrelation = dto.IdCorrelation;
        //    Environment = dto.Environment;
        //    LogLevel = dto.LogLevel;
        //    LoggerName = dto.LoggerName;
        //    ServerName = dto.ServerName;
        //    LineNumber = dto.LineNumber;
        //    FileName = dto.FileName;
        //    LogDate = dto.LogDate;
        //}
        //#endregion
    }
}
