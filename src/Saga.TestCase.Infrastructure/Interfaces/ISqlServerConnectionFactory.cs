using System.Data;

namespace Saga.TestCase.Infrastructure.Interfaces
{
    public interface ISqlServerConnectionFactory
    {
        IDbConnection GetDbConnection(string connectionName);
    }
}
