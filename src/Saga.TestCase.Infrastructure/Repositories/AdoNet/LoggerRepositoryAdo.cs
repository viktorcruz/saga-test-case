using Saga.TestCase.Domain.Entities;
using Saga.TestCase.Infrastructure.Interfaces;
using System.Data.SqlClient;

namespace Saga.TestCase.Infrastructure.Repositories.AdoNet
{
    public class LoggerRepositoryAdo : ILoggerRepository
    {
        #region Properties
        private readonly ISqlServerConnectionFactory _connectionFactory;
        private readonly string SagaConnection = "Wagner";
        #endregion

        #region Constructor
        public LoggerRepositoryAdo(ISqlServerConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #endregion

        #region Methods
        public Task<List<LoggerEntity>> GetAllLoggerAsync()
        {
            List<LoggerEntity> logs = new List<LoggerEntity>();

            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();
                var query = @"
                    SELECT 
                        A.IdLog,
                        A.IdCorrelation, 
	                    A.Environment, 
	                    A.LogLevel, 
	                    A.LoggerName, 
	                    E.ServerName, 
	                    E.LineNumber, 
	                    E.FileName, 
	                    E.LogDate from 
                    ApplicationLogs A (NOLOCK)
	                    INNER JOIN ErrorDetailsLogs E ON A.IdCorrelation = E.IdCorrelation
                    ORDER BY E.LogDate DESC
                    ";

                using (var command = new SqlCommand(query, connection as SqlConnection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var log = new LoggerEntity(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetInt32(6),
                            reader.GetString(7),
                            reader.GetDateTime(8)
                        );

                        logs.Add(log);
                    }
                }
            }
            return Task.FromResult(logs);

        }
        #endregion
    }
}
