using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saga.TestCase.Infrastructure.Common;
using Saga.TestCase.Infrastructure.Exceptions;
using Saga.TestCase.Infrastructure.Factory;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Infrastructure.Repositories;
using Saga.TestCase.Infrastructure.Repositories.AdoNet;
using Saga.TestCase.Infrastructure.Repositories.Dapper;

namespace Saga.TestCase.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomInfrastructureIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddSingleton<ISqlServerConnectionFactory, SqlServerConnectionFactory>();

            services.AddSingleton<IClientesRepository, ClientesRepositoryAdo>();
            services.AddSingleton<IClientesRepository, ClientesRepositoryDapper>();
            services.AddSingleton<ClientesRepositoryFactory>();
            services.AddSingleton<ClientesRepositoryAdo>();

            
            services.AddSingleton<ILoggerRepository, LoggerRepositoryAdo>();
            services.AddSingleton<LoggerRepositoryAdo>();
            services.AddSingleton<LoggerRepositoryFactory>();



            services.AddSingleton<IGlobalExceptionHandler, GlobalExceptionHandler>();
            services.AddSingleton<ICorrelationCommon, CorrelationCommon>();

            return services;
        }
    }
}
