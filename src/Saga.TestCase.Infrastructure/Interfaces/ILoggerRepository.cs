using Saga.TestCase.Domain.Entities;

namespace Saga.TestCase.Infrastructure.Interfaces
{
    public interface ILoggerRepository
    {
        Task<List<LoggerEntity>> GetAllLoggerAsync();
    }
}
