using Saga.TestCase.Domain.Entities;
using Saga.TestCase.Transversal.Responses;

namespace Saga.TestCase.Infrastructure.Interfaces
{
    public interface IProductosRepository
    {
        Task<bool> CreateProductosAsync(ProductosEntity productosEntity);
        Task<bool> UpdateProductosAsync(ProductosEntity productosEntity);
        Task<bool> DeleteProductosAsync(string productoId);

        Task<PagedResult<ProductosEntity>> GetProductosPaginatedAsync(int pageNumber, int pageSize, string? search);
        Task<ProductosEntity> GetProductosByIdAsync(ProductosEntity productosEntity);
    }
}
