using Dapper;
using Saga.TestCase.Domain.Entities;
using Saga.TestCase.Infrastructure.Factory;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Transversal.Responses;
using System.Data;

namespace Saga.TestCase.Infrastructure.Repositories.Dapper
{
    public class ClientesRepositoryDapper : IClientesRepository
    {
        #region Properties
        private readonly ISqlServerConnectionFactory _connectionFactory;
        private readonly IGlobalExceptionHandler _globalExceptionHandler;
        private readonly string SagaConnection = "Wagner";
        #endregion

        #region Constructor
        public ClientesRepositoryDapper(ISqlServerConnectionFactory connectionFactory, IGlobalExceptionHandler globalExceptionHandler)
        {
            _connectionFactory = connectionFactory;
            _globalExceptionHandler = globalExceptionHandler;
        }
        #endregion

        #region Methods
        public async Task<bool> CreateClientesAsync(ClientesEntity clientesEntity)
        {
            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        var query = "Usp_Clientes_Insert";
                        var parameters = new DynamicParameters();
                        parameters.Add("@Id", clientesEntity.Id);
                        parameters.Add("@Nombre", clientesEntity.Nombre);
                        parameters.Add("@Apellido", clientesEntity.Apellido);
                        parameters.Add("@RFC", clientesEntity.RFC);
                        parameters.Add("@CuentaBancariaId", clientesEntity.CuentaBancariaId);

                        var results = await connection.QueryAsync<ClientesEntity>(
                            query,
                            parameters,
                            transaction: transaction,
                            commandType: CommandType.StoredProcedure);

                        transaction.Commit();

                        if (results != null)
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _globalExceptionHandler.CaptureException<string>(ex, ApplicationLayer.Infrastructure, ActionType.Create);
                    }
                    return false;
                }

            }
        }

        public async Task<bool> DeleteClientesAsync(string clienteId)
        {
            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var query = "Usp_Clientes_Delete";
                        var parameters = new DynamicParameters();
                        parameters.Add("@Id", clienteId);

                        var results = await connection.QueryAsync<ClientesEntity>(
                            query,
                            parameters,
                            transaction: transaction,
                            commandType: CommandType.StoredProcedure);

                        transaction.Commit();

                        if (results != null)
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _globalExceptionHandler.CaptureException<string>(ex, ApplicationLayer.Infrastructure, ActionType.Delete);
                    }
                    return false;
                }
            }
        }

        public Task<ClientesEntity> GetClientesByIdAsync(ClientesEntity clientesEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ClientesEntity>> GetClientesPaginatedAsync(int pageNumber, int pageSize, string search)
        {
            var clientes = new List<ClientesEntity>();
            int totalCount = 0;

            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                try
                {
                    var query = "Usp_Clientes_GetPage";
                    var parameters = new DynamicParameters();
                    parameters.Add("@PageNumber", pageNumber, DbType.Int32);
                    parameters.Add("@PageSize", pageSize, DbType.Int32);
                    parameters.Add("@Search", search, DbType.String);

                    using (var m = await connection.QueryMultipleAsync(query, parameters, commandType: CommandType.StoredProcedure))
                    {
                        clientes = m.Read<ClientesEntity>().ToList();
                        totalCount = m.Read<int>().FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    _globalExceptionHandler.CaptureException<string>(ex, ApplicationLayer.Infrastructure, ActionType.FetchAll);
                }

                return new PagedResult<ClientesEntity>(
                        items: clientes,
                        totalCount: totalCount,
                        currentPage: pageNumber,
                        pageSize: pageSize
                    );
            }
        }

        public async Task<bool> UpdateClientesAsync(ClientesEntity clientesEntity)
        {
            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var query = "Usp_Clientes_Update";
                        var parameters = new DynamicParameters();
                        parameters.Add("@Id", clientesEntity.Id);
                        parameters.Add("@Nombre", clientesEntity.Nombre);
                        parameters.Add("@Apellido", clientesEntity.Apellido);
                        parameters.Add("@RFC", clientesEntity.RFC);
                        parameters.Add("@CuentaBancariaId", clientesEntity.CuentaBancariaId);

                        var results = await connection.QueryAsync<ClientesEntity>(
                            query,
                            parameters,
                            transaction: transaction,
                            commandType: CommandType.StoredProcedure);

                        transaction.Commit();

                        if (results != null)
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _globalExceptionHandler.CaptureException<string>(ex, ApplicationLayer.Infrastructure, ActionType.Update);
                    }
                    return false;
                }
            }
        }
        #endregion
    }
}
