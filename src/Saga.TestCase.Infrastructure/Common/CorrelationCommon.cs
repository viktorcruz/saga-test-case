using Saga.TestCase.Infrastructure.Interfaces;

namespace Saga.TestCase.Infrastructure.Common
{
    public class CorrelationCommon : ICorrelationCommon
    {
        public string GetCorrelationId()
        {
            return NLog.GlobalDiagnosticsContext.Get("IdCorrelation");
        }
    }
}
