using NLog;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Transversal.Interfaces;
using Saga.TestCase.Transversal.Responses;
using System.Diagnostics;

namespace Saga.TestCase.Infrastructure.Exceptions
{
    public class GlobalExceptionHandler : IGlobalExceptionHandler
    {
        private readonly ICorrelationCommon _correlationCommon;

        public GlobalExceptionHandler(ICorrelationCommon correlationCommon)
        {
            _correlationCommon = correlationCommon;
        }

        public IResponseToClient<TResponse> CaptureException<TResponse>(Exception ex, ApplicationLayer layer, ActionType action)
        {
            try
            {
                var logger = LogManager.GetCurrentClassLogger();
                if (logger == null)
                {
                    throw new Exception("NLog no está configurado correctamente. Verifica el archivo nlog.config.");
                }

                var layerName = layer.ToString();
                var actionName = action.ToString();
                var appBasePath = Directory.GetCurrentDirectory();
                NLog.GlobalDiagnosticsContext.Set("appbasepath", appBasePath);

                IResponseToClient<TResponse> response = new ResponseToClient<TResponse>
                {
                    IsSuccess = false,
                    Message = "Error"
                };

                var idCorrelation = _correlationCommon.GetCorrelationId();

                var logSharedEvent = CreateLogSharedEvent(ex, layerName, actionName, logger, idCorrelation);
                LogShared(logSharedEvent);

                return response;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Fallo el manejador de Log: {e}");
                throw;
            }
        }

        public void CaptureOperations(string action, string message)
        {
            var logger = LogManager.GetCurrentClassLogger();
            var logEvent = LogEventInfo.Create(LogLevel.Info, logger.Name, message);

            logEvent.Properties["Action"] = action;
            logEvent.Properties["Message"] = message;
            LogByOperations(logEvent);
        }

        private void AddCommonLogProperties(Exception ex, Logger logger, string idCorrelation, LogEventInfo logEvent)
        {
            var stackTrace = new StackTrace(ex, true);
            var frame = stackTrace.GetFrame(0);

            logEvent.Properties["IdCorrelation"] = idCorrelation;
            logEvent.Properties["ServerName"] = Environment.MachineName ?? "Unknown";
            logEvent.Properties["FileName"] = frame?.GetFileName() ?? "Unknown";
            logEvent.Properties["LineNumber"] = frame?.GetFileLineNumber() ?? 0;
            logEvent.Properties["LogData"] = DateTime.UtcNow;
            logEvent.Properties["ThreadId"] = Thread.CurrentThread.ManagedThreadId;
            logEvent.Properties["Exception"] = ex.ToString();
            logEvent.Properties["Message"] = ex.ToString();
            logEvent.Properties["ExceptionStackTrace"] = ex.StackTrace;

            logEvent.Properties["LoggerName"] = logger.Name ?? "DefaultLogger";
            logEvent.Properties["MachineName"] = Environment.MachineName;
            logEvent.Properties["Username"] = Environment.UserName ?? "Unknown";
        }

        private LogEventInfo CreateLogSharedEvent(Exception ex, string layerName, string actionName, Logger logger, string idCorrelation)
        {
            var stackTrace = new StackTrace(ex, true);
            var frame = stackTrace.GetFrame(0);
            var logEvent = LogEventInfo.Create(LogLevel.Error, logger.Name, $"Exception in {layerName}.{actionName}: {ex.Message}");

            AddCommonLogProperties(ex, logger, idCorrelation, logEvent);

            logEvent.Exception = ex;
            logEvent.Properties["Layer"] = layerName;
            logEvent.Properties["Action"] = actionName;
            logEvent.Properties["LogLevel"] = "Error";

            return logEvent;
        }
        private void LogByOperations(LogEventInfo logEvent)
        {
            try
            {
                var logger = LogManager.GetLogger("DatabaseOperationsLog");
                logger.Log(logEvent);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fallo el manjedor de Log: {e}");
                throw;
            }
        }

        private void LogShared(LogEventInfo logEvent)
        {
            try
            {
                var logger = LogManager.GetLogger("DatabaseGeneralLog");
                logger.Log(logEvent);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fallo el manejador de Log: {e}");
                throw;
            }
        }
    }
}
