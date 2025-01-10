using Saga.TestCase.Infrastructure.Exceptions.Dto;
using Saga.TestCase.Transversal.Interfaces;

namespace Saga.TestCase.Infrastructure.Interfaces
{
    public interface IGlobalExceptionHandler
    {
        IResponseToClient<TResponse> CaptureException<TResponse>(Exception ex, ApplicationLayer layer, ActionType action);
        void CaptureOperations(string actionName, string actionMessage);
    }
}
