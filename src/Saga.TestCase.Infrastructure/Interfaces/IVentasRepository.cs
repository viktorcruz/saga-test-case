using Saga.TestCase.Domain.Entities;
using Saga.TestCase.Transversal.Responses;

namespace Saga.TestCase.Infrastructure.Interfaces
{
    public interface IVentasRepository
    {
        Task<bool> CreateVentasAsync(VentasEntity ventasEntity);
        Task<bool> UpdateVentasAsync(VentasEntity ventasEntity);
        Task<bool> DeleteVentasAsync(string ventaId);

        Task<PagedResult<VentasEntity>> GetVentasPaginatedAsync(int pageNumber, int pageSize, string? search);
        Task<VentasEntity> GetVentasByIdAsync(VentasEntity ventasEntity);
    }
}