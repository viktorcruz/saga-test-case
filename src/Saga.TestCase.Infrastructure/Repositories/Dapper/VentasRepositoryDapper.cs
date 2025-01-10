using Dapper;
using Saga.TestCase.Domain.Entities;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Transversal.Responses;
using System.Data;

namespace Saga.TestCase.Infrastructure.Repositories.Dapper
{
    internal class VentasRepositoryDapper : IVentasRepository
    {
        #region Properties
        private readonly ISqlServerConnectionFactory _connectionFactory;
        private readonly IGlobalExceptionHandler _globalExceptionHandler;
        private readonly string SagaConnection = "Wagner";
        #endregion

        #region Constructor
        public VentasRepositoryDapper(ISqlServerConnectionFactory connectionFactory, IGlobalExceptionHandler globalExceptionHandler)
        {
            _connectionFactory = connectionFactory;
            _globalExceptionHandler = globalExceptionHandler;
        }
        #endregion

        #region Methods
        public async Task<bool> CreateVentasAsync(VentasEntity ventasEntity)
        {
            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        var query = "Usp_Ventas_Insert";
                        var parameters = new DynamicParameters();
                        parameters.Add("@Id", ventasEntity.Id);
                        parameters.Add("@Folio", ventasEntity.Folio);
                        parameters.Add("@Cantidad", ventasEntity.Cantidad);
                        parameters.Add("@CodigoTasaIva", ventasEntity.CodigoTasaIva);
                        parameters.Add("@PrecioUnitario", ventasEntity.PrecioUnitario);
                        parameters.Add("@SubTotal", ventasEntity.SubTotal);
                        parameters.Add("@IVA", ventasEntity.IVA);
                        parameters.Add("@ImporteTotal", ventasEntity.ImporteTotal);
                        parameters.Add("@FechaVenta", ventasEntity.FechaVenta);
                        parameters.Add("@Activo", ventasEntity.Activo);

                        var results = await connection.QueryAsync<VentasEntity>(
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

        public async Task<bool> DeleteVentasAsync(string ventaId)
        {
            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var query = "Usp_Ventas_Delete";
                        var parameters = new DynamicParameters();
                        parameters.Add("@Id", ventaId);

                        var results = await connection.QueryAsync<VentasEntity>(
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

        public Task<VentasEntity> GetVentasByIdAsync(VentasEntity ventasEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<VentasEntity>> GetVentasPaginatedAsync(int pageNumber, int pageSize, string search)
        {
            var ventas = new List<VentasEntity>();
            int totalCount = 0;

            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                try
                {
                    var query = "Usp_Ventas_GetPage";
                    var parameters = new DynamicParameters();
                    parameters.Add("@PageNumber", pageNumber, DbType.Int32);
                    parameters.Add("@PageSize", pageSize, DbType.Int32);
                    parameters.Add("@Search", search, DbType.String);

                    using (var m = await connection.QueryMultipleAsync(query, parameters, commandType: CommandType.StoredProcedure))
                    {
                        ventas = m.Read<VentasEntity>().ToList();
                        totalCount = m.Read<int>().FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    _globalExceptionHandler.CaptureException<string>(ex, ApplicationLayer.Infrastructure, ActionType.FetchAll);
                }

                return new PagedResult<VentasEntity>(
                        items: ventas,
                        totalCount: totalCount,
                        currentPage: pageNumber,
                        pageSize: pageSize
                    );
            }
        }

        public async Task<bool> UpdateVentasAsync(VentasEntity ventasEntity)
        {
            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var query = "Usp_Ventas_Update";
                        var parameters = new DynamicParameters();
                        parameters.Add("@Id", ventasEntity.Id);
                        parameters.Add("@Folio", ventasEntity.Folio);
                        parameters.Add("@Cantidad", ventasEntity.Cantidad);
                        parameters.Add("@CodigoTasaIva", ventasEntity.CodigoTasaIva);
                        parameters.Add("@PrecioUnitario", ventasEntity.PrecioUnitario);
                        parameters.Add("@SubTotal", ventasEntity.SubTotal);
                        parameters.Add("@IVA", ventasEntity.IVA);
                        parameters.Add("@ImporteTotal", ventasEntity.ImporteTotal);
                        parameters.Add("@FechaVenta", ventasEntity.FechaVenta);
                        parameters.Add("@Activo", ventasEntity.Activo);

                        var results = await connection.QueryAsync<ProductosEntity>(
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
