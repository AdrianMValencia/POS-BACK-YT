using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Commons.Bases.Request;
using POS.Application.Dtos.Sale.Request;
using POS.Application.Interfaces;
using POS.Utilities.Static;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleApplication _saleApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;

        public SaleController(ISaleApplication saleApplication, IGenerateExcelApplication generateExcelApplication)
        {
            _saleApplication = saleApplication;
            _generateExcelApplication = generateExcelApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListSales([FromQuery] BaseFiltersRequest filters)
        {
            var response = await _saleApplication.ListSales(filters);

            if ((bool)filters.Download!)
            {
                var columnNames = ExcelColumnNames.GetColumnsSales();
                var fileBytes = _generateExcelApplication.GenerateToExcel(response.Data!, columnNames);
                return File(fileBytes, ContentType.ContentTypeExcel);
            }

            return Ok(response);
        }

        [HttpGet("{saleId:int}")]
        public async Task<IActionResult> SaleById(int saleId)
        {
            var response = await _saleApplication.SaleById(saleId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterSale([FromBody] SaleRequestDto requestDto)
        {
            var response = await _saleApplication.RegisterSale(requestDto);
            return Ok(response);
        }

        [HttpPut("Cancel/{saleId:int}")]
        public async Task<IActionResult> CancelSale(int saleId)
        {
            var response = await _saleApplication.CancelSale(saleId);
            return Ok(response);
        }

        [HttpGet("ProductStockByWarehouse")]
        public async Task<IActionResult> GetProductStockByWarehouseId([FromQuery] BaseFiltersRequest filters)
        {
            var response = await _saleApplication.GetProductStockByWarehouseId(filters);
            return Ok(response);
        }
    }
}
