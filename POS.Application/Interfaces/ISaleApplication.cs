using POS.Application.Commons.Bases.Request;
using POS.Application.Commons.Bases.Response;
using POS.Application.Dtos.Sale.Request;
using POS.Application.Dtos.Sale.Response;

namespace POS.Application.Interfaces
{
    public interface ISaleApplication
    {
        Task<BaseResponse<IEnumerable<SaleResponseDto>>> ListSales(BaseFiltersRequest filters);
        Task<BaseResponse<SaleByIdResponseDto>> SaleById(int saleId);
        Task<BaseResponse<bool>> RegisterSale(SaleRequestDto requestDto);
        Task<BaseResponse<bool>> CancelSale(int saleId);
        Task<BaseResponse<IEnumerable<ProductStockByWarehouseIdResponseDto>>> GetProductStockByWarehouseId(BaseFiltersRequest filters);
    }
}
