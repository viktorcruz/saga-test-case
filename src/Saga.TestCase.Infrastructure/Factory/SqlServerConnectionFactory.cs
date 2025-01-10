using Microsoft.Extensions.Configuration;
using Saga.TestCase.Infrastructure.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Saga.TestCase.Infrastructure.Factory
{
    public class SqlServerConnectionFactory : ISqlServerConnectionFactory
    {
        #region Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public SqlServerConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Methods
        public IDbConnection GetDbConnection(string connectionString)
        {
            var connection = _configuration.GetConnectionString(connectionString);

            if (connection == null)
            {
                throw new ArgumentException("La conection no debe de estar vacia.");
            }

            return new SqlConnection(connection);
        }
        #endregion
    }
}
