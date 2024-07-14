namespace POS.Application.Dtos.Sale.Response
{
    public class ProductStockByWarehouseIdResponseDto
    {
        public int ProductId { get; set; }
        public string? Image {  get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal UnitSalePrice {  get; set; }
        public int CurrentStock { get; set; }
    }
}
