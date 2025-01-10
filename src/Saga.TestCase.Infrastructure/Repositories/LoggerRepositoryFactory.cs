using Microsoft.Extensions.DependencyInjection;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Infrastructure.Repositories.AdoNet;

namespace Saga.TestCase.Infrastructure.Repositories
{
    public class LoggerRepositoryFactory 
    {
        #region Properties
        private readonly IServiceProvider _serviceProvider;
        #endregion

        #region Constructor
        public LoggerRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        #endregion

        #region Methods
        public ILoggerRepository GetRepository(string type)
        {
            return type switch
            {
                "ADO" => _serviceProvider.GetRequiredService<LoggerRepositoryAdo>(),
                //"Dapper" => _serviceProvider.GetRequiredService<ClientesRepositoryDapper>(),
                //"SP" => _serviceProvider.GetRequiredService<ClientesRepositorySp>(),
                _ => throw new ArgumentException("Tipo de repositorio no valido")
            };
        }
        #endregion
    }
}
