using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS.Application.Commons.Bases.Request;
using POS.Application.Commons.Bases.Response;
using POS.Application.Commons.Ordering;
using POS.Application.Dtos.Product.Request;
using POS.Application.Dtos.Product.Response;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchDog;

namespace POS.Application.Services
{
    public class ProductApplication : IProductApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderingQuery _orderingQuery;
        private readonly IFileStorageLocalApplication _fileStorage;

        public ProductApplication(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery orderingQuery, IFileStorageLocalApplication fileStorage)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderingQuery = orderingQuery;
            _fileStorage = fileStorage;
        }

        public async Task<BaseResponse<IEnumerable<ProductResponseDto>>> ListProducts(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<IEnumerable<ProductResponseDto>>();

            try
            {
                var products = _unitOfWork.Product.GetAllQueryable()
                    .Include(x => x.Category)
                    .AsQueryable();

                if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
                {
                    switch (filters.NumFilter)
                    {
                        case 1:
                            products = products.Where(x => x.Code!.Contains(filters.TextFilter));
                            break;
                        case 2:
                            products = products.Where(x => x.Name!.Contains(filters.TextFilter));
                            break;
                    }
                }

                if (filters.StateFilter is not null)
                {
                    products = products.Where(x => x.State.Equals(filters.StateFilter));
                }

                if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
                {
                    products = products.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate)
                        && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate)
                        .AddDays(1));
                }

                filters.Sort ??= "Id";

                var items = await _orderingQuery.Ordering(filters, products, !(bool)filters.Download!).ToListAsync();

                response.IsSuccess = true;
                response.TotalRecords = await products.CountAsync();
                response.Data = _mapper.Map<IEnumerable<ProductResponseDto>>(items);
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

        public async Task<BaseResponse<ProductByIdResponseDto>> ProductById(int productId)
        {
            var response = new BaseResponse<ProductByIdResponseDto>();

            try
            {
                var product = await _unitOfWork.Product.GetByIdAsync(productId);

                if (product is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<ProductByIdResponseDto>(product);
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

        public async Task<BaseResponse<bool>> RegisterProduct(ProductRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var product = _mapper.Map<Product>(requestDto);

                if (requestDto.Image is not null)
                    product.Image = await _fileStorage.SaveFile(AzureContainers.PRODUCTS, requestDto.Image);

                await _unitOfWork.Product.RegisterAsync(product);
                int productId = product.Id;
                var warehouses = await _unitOfWork.Warehouse.GetAllAsync();

                await RegisterProductStockAsync(warehouses, productId);

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

        public async Task<BaseResponse<bool>> EditProduct(int productId, ProductRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var pathImage = await ProductById(productId);
                var product = _mapper.Map<Product>(requestDto);

                if (requestDto.Image is not null)
                    product.Image = await _fileStorage
                        .EditFile(AzureContainers.PRODUCTS, requestDto.Image, pathImage.Data!.Image!);

                if (requestDto.Image is null)
                    product.Image = pathImage.Data!.Image;

                product.Id = productId;
                await _unitOfWork.Product.EditAsync(product);

                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }
        
        public async Task<BaseResponse<bool>> RemoveProduct(int productId)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var product = await ProductById(productId);

                response.Data = await _unitOfWork.Product.RemoveAsync(productId);

                await _fileStorage.RemoveFile(product.Data!.Image!, AzureContainers.PRODUCTS);

                if (!response.Data)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                    return response;
                }

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

        private async Task RegisterProductStockAsync(
            IEnumerable<Warehouse> warehouses,
            int productId)
        {
            foreach (var warehouse in warehouses)
            {
                var newProductStock = new ProductStock
                {
                    ProductId = productId,
                    WarehouseId = warehouse.Id,
                    CurrentStock = 0,
                    PurchasePrice = 0
                };

                await _unitOfWork.ProductStock.RegisterProductStock(newProductStock);
            }
        }
    }
}