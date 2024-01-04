using Microsoft.AspNetCore.Http;

namespace POS.Application.Dtos.Product.Request
{
    public class ProductRequestDto
    {
        public string? Code {  get; set; }
        public string? Name { get; set; }
        public int StockMin {  get; set; }
        public int StockMax { get; set;}
        public IFormFile? Image { get; set; }
        public decimal UnitSalePrice {  get; set; }
        public int CategoryId {  get; set; }
        public int State {  get; set; }
    }
}