using Saga.TestCase.Domain.Entities;
using Saga.TestCase.Transversal.Responses;

namespace Saga.TestCase.Infrastructure.Interfaces
{
    public interface IClientesRepository
    {
        Task<bool> CreateClientesAsync(ClientesEntity clientesEntity);
        Task<bool> UpdateClientesAsync(ClientesEntity clientesEntity);
        Task<bool> DeleteClientesAsync(string clienteId);

        Task<PagedResult<ClientesEntity>> GetClientesPaginatedAsync(int pageNumber, int pageSize, string? search);
        Task<ClientesEntity> GetClientesByIdAsync(ClientesEntity clientesEntity);
    }
}
