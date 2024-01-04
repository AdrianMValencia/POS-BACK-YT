using POS.Domain.Entities;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IProductStockRepository
    {
        Task<bool> RegisterProductStock(ProductStock productStock);
        Task<IEnumerable<ProductStock>> GetProductStockByWarehouse(int productId);
        Task<ProductStock> GetProductStockByProductId(int productId, int warehouseId);
        Task<bool> UpdateCurrentStockByProducts(ProductStock productStock);
    }
}