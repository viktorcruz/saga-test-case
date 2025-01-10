using Microsoft.Extensions.DependencyInjection;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Infrastructure.Repositories.AdoNet;
using Saga.TestCase.Infrastructure.Repositories.Dapper;

namespace Saga.TestCase.Infrastructure.Repositories
{
    public class ClientesRepositoryFactory
    {
        #region Properties
        private readonly IServiceProvider _serviceProvider;
        #endregion

        #region Constructor
        public ClientesRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        #endregion

        #region Methods
        public IClientesRepository GetRepository(string type)
        {
            return type switch
            {
                "ADO" => _serviceProvider.GetRequiredService<ClientesRepositoryAdo>(),
                "Dapper" => _serviceProvider.GetRequiredService<ClientesRepositoryDapper>(),
                _ => throw new ArgumentException("Tipo de repositorio no valido")
            };
        }
        #endregion
    }
}

