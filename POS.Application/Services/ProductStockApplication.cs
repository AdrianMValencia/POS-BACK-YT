using AutoMapper;
using POS.Application.Commons.Bases.Response;
using POS.Application.Dtos.ProductStock;
using POS.Application.Interfaces;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;
using WatchDog;

namespace POS.Application.Services
{
    public class ProductStockApplication : IProductStockApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductStockApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<ProductStockByWarehouseResponseDto>>> 
            GetProductStockByWarehouseAsync(int productId)
        {
            var response = new BaseResponse<IEnumerable<ProductStockByWarehouseResponseDto>>();

            try
            {
                var productStockByWarehouse = await _unitOfWork
                    .ProductStock
                    .GetProductStockByWarehouse(productId);

                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<ProductStockByWarehouseResponseDto>>
                    (productStockByWarehouse);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }
    }
}