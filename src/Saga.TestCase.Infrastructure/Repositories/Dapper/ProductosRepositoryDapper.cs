using Dapper;
using Saga.TestCase.Domain.Entities;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Transversal.Responses;
using System.Data;

namespace Saga.TestCase.Infrastructure.Repositories.Dapper
{
    public class ProductosRepositoryDapper : IProductosRepository
    {
        #region Properties
        private readonly ISqlServerConnectionFactory _connectionFactory;
        private readonly IGlobalExceptionHandler _globalExceptionHandler;
        private readonly string SagaConnection = "Wagner";
        #endregion

        #region Constructor
        public ProductosRepositoryDapper(ISqlServerConnectionFactory connectionFactory, IGlobalExceptionHandler globalExceptionHandler)
        {
            _connectionFactory = connectionFactory;
            _globalExceptionHandler = globalExceptionHandler;
        }
        #endregion

        #region Methods
        public async Task<bool> CreateProductosAsync(ProductosEntity productosEntity)
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
                        parameters.Add("@Id", productosEntity.Id);
                        parameters.Add("@Nombre", productosEntity.Nombre);
                        parameters.Add("@Descripcion", productosEntity.Descripcion);
                        parameters.Add("@PrecioCompra", productosEntity.PrecioCompra);
                        parameters.Add("@PrecioPublico", productosEntity.PrecioPublico);
                        parameters.Add("@PrecioEspecial", productosEntity.PrecioEspecial);
                        parameters.Add("@Activo", productosEntity.Activo);

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

        public async Task<bool> DeleteProductosAsync(string productoId)
        {
            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var query = "Usp_Productos_Delete";
                        var parameters = new DynamicParameters();
                        parameters.Add("@Id", productoId);

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
                        _globalExceptionHandler.CaptureException<string>(ex, ApplicationLayer.Infrastructure, ActionType.Delete);
                    }
                    return false;
                }
            }
        }

        public Task<ProductosEntity> GetProductosByIdAsync(ProductosEntity productosEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductosEntity>> GetProductosPaginatedAsync(int pageNumber, int pageSize, string search)
        {
            var productos = new List<ProductosEntity>();
            int totalCount = 0;

            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                try
                {
                    var query = "Usp_Productos_GetPage";
                    var parameters = new DynamicParameters();
                    parameters.Add("@PageNumber", pageNumber, DbType.Int32);
                    parameters.Add("@PageSize", pageSize, DbType.Int32);
                    parameters.Add("@Search", search, DbType.String);

                    using (var m = await connection.QueryMultipleAsync(query, parameters, commandType: CommandType.StoredProcedure))
                    {
                        productos = m.Read<ProductosEntity>().ToList();
                        totalCount = m.Read<int>().FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    _globalExceptionHandler.CaptureException<string>(ex, ApplicationLayer.Infrastructure, ActionType.FetchAll);
                }

                return new PagedResult<ProductosEntity>(
                        items: productos,
                        totalCount: totalCount,
                        currentPage: pageNumber,
                        pageSize: pageSize
                    );
            }
        }

        public async Task<bool> UpdateProductosAsync(ProductosEntity productosEntity)
        {
            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var query = "Usp_Productos_Update";
                        var parameters = new DynamicParameters();
                        parameters.Add("@Id", productosEntity.Id);
                        parameters.Add("@Nombre", productosEntity.Nombre);
                        parameters.Add("@Descripcion", productosEntity.Descripcion);
                        parameters.Add("@PrecioCompra", productosEntity.PrecioCompra);
                        parameters.Add("@PrecioPublico", productosEntity.PrecioPublico);
                        parameters.Add("@PrecioEspecial", productosEntity.PrecioEspecial);
                        parameters.Add("@Activo", productosEntity.Activo);

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
