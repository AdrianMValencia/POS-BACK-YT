namespace POS.Application.Dtos.Sale.Request
{
    public class SaleDetailRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitSalePrice { get; set; }
        public decimal Total { get; set; }
    }
}
