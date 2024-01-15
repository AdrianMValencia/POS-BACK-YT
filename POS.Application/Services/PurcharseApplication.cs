using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS.Application.Commons.Bases.Request;
using POS.Application.Commons.Bases.Response;
using POS.Application.Commons.Ordering;
using POS.Application.Dtos.Purcharse.Request;
using POS.Application.Dtos.Purcharse.Response;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;
using WatchDog;

namespace POS.Application.Services
{
    public class PurcharseApplication : IPurcharseApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderingQuery _orderingQuery;

        public PurcharseApplication(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery orderingQuery)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderingQuery = orderingQuery;
        }


        public async Task<BaseResponse<IEnumerable<PurcharseResponseDto>>> 
            ListPurcharses(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<IEnumerable<PurcharseResponseDto>>();

            try
            {
                var purcharses = _unitOfWork.Purcharse.GetAllQueryable()
                    .AsNoTracking()
                    .Include(x => x.Provider)
                    .Include(x => x.Warehouse)
                    .AsQueryable();

                if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
                {
                    switch (filters.NumFilter)
                    {
                        case 1:
                            purcharses = purcharses.Where(x => x.Provider!.Name!.Contains(filters.TextFilter));
                            break;
                    }
                }

                //if (filters.StateFilter is not null)
                //{
                //    purcharses = purcharses.Where(x => x.State.Equals(filters.StateFilter));
                //}

                if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
                {
                    purcharses = purcharses.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate)
                        && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate)
                        .AddDays(1));
                }

                filters.Sort ??= "Id";

                var items = await _orderingQuery.Ordering(filters, purcharses, !(bool)filters.Download!).ToListAsync();

                response.IsSuccess = true;
                response.TotalRecords = await purcharses.CountAsync();
                response.Data = _mapper.Map<IEnumerable<PurcharseResponseDto>>(items);
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

        public async Task<BaseResponse<PurcharseByIdResponseDto>> PurcharseById(int purcharseId)
        {
            var response = new BaseResponse<PurcharseByIdResponseDto>();

            try
            {
                var purcharse = await _unitOfWork.Purcharse.GetByIdAsync(purcharseId);

                if (purcharse is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                var purcharseDetails = await _unitOfWork.PurcharseDetail
                    .GetPurcharseDetailByPurcharseId(purcharse.Id);

                purcharse.PurcharseDetails = purcharseDetails.ToList();

                response.IsSuccess = true;
                response.Data = _mapper.Map<PurcharseByIdResponseDto>(purcharse);
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

        public async Task<BaseResponse<bool>> RegisterPurcharse(PurcharseRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var purcharse = _mapper.Map<Purcharse>(requestDto);
                purcharse.State = (int)StateTypes.Active;
                await _unitOfWork.Purcharse.RegisterAsync(purcharse);

                foreach (var item in purcharse.PurcharseDetails)
                {
                    var productStock = await _unitOfWork.ProductStock
                        .GetProductStockByProductId(item.ProductId, requestDto.WarehouseId);
                    productStock.CurrentStock += item.Quantity;
                    productStock.PurchasePrice = item.UnitPurcharsePrice;
                    await _unitOfWork.ProductStock.UpdateCurrentStockByProducts(productStock);
                }

                transaction.Commit();
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }
        
        public async Task<BaseResponse<bool>> CancelPurcharse(int purcharseId)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var purcharse = await PurcharseById(purcharseId);

                response.Data = await _unitOfWork.Purcharse.RemoveAsync(purcharseId);

                foreach(var item in purcharse.Data!.PurcharseDetails)
                {
                    var productStock = await _unitOfWork.ProductStock
                        .GetProductStockByProductId(item.ProductId, purcharse.Data.WarehouseId);
                    productStock.CurrentStock -= item.Quantity;
                    await _unitOfWork.ProductStock.UpdateCurrentStockByProducts(productStock);
                }

                transaction.Commit();
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
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