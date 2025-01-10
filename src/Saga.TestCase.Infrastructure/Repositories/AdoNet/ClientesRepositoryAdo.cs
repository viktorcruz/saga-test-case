using Saga.TestCase.Domain.Entities;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Transversal.Responses;
using System.Data.SqlClient;

namespace Saga.TestCase.Infrastructure.Repositories.AdoNet
{
    public class ClientesRepositoryAdo : IClientesRepository
    {
        #region Properties
        private readonly ISqlServerConnectionFactory _connectionFactory;
        private readonly string SagaConnection = "Wagner";
        #endregion

        #region Constructor
        public ClientesRepositoryAdo(ISqlServerConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #endregion


        #region Methods
        public Task<bool> CreateClientesAsync(ClientesEntity clientesEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteClientesAsync(string clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<ClientesEntity> GetClientesByIdAsync(ClientesEntity clientesEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ClientesEntity>> GetClientesPaginatedAsync(int pageNumber, int pageSize, string search)
        {
            var clientes = new List<ClientesEntity>();
            int totalCount;

            using (var connection = _connectionFactory.GetDbConnection(SagaConnection))
            {
                connection.Open();
                var query = @"
                    SELECT * 
                    FROM Clientes
                    WHERE Nombre LIKE '%' + @Search + '%' 
                       OR Apellido LIKE '%' + @Search + '%' 
                       OR RFC LIKE '%' + @Search + '%'
                    ORDER BY Nombre
                    OFFSET (@PageNumber - 1) * @PageSize ROWS
                    FETCH NEXT @PageSize ROWS ONLY;

                    SELECT COUNT(*) AS TotalCount 
                    FROM Clientes
                    WHERE Nombre LIKE '%' + @Search + '%' 
                       OR Apellido LIKE '%' + @Search + '%' 
                       OR RFC LIKE '%' + @Search + '%';
                ";

                using (var command = new SqlCommand(query, connection as SqlConnection))
                {
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@Search", search ?? string.Empty);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clientes.Add(new ClientesEntity
                            {
                                Id = reader.GetString(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                                RFC = reader.GetString(reader.GetOrdinal("RFC")),
                                CuentaBancariaId = reader.GetString(reader.GetOrdinal("CuentaBancariaId"))
                            });
                        }

                        if (await reader.NextResultAsync())
                        {
                            await reader.ReadAsync();
                            totalCount = reader.GetInt32(reader.GetOrdinal("TotalCount"));
                        }
                        else
                        {
                            throw new InvalidOperationException("Error al leer el conteo total.");
                        }
                    }
                }
            }
            return new PagedResult<ClientesEntity>(
                items: clientes,             // Lista de clientes obtenida
                totalCount: totalCount,      // Total de registros en la base de datos
                currentPage: pageNumber,     // Número de página actual
                pageSize: pageSize           // Tamaño de la página
            );
        }

        public Task<bool> UpdateClientesAsync(ClientesEntity clientesEntity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
