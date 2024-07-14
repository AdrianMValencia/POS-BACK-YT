namespace POS.Application.Dtos.Sale.Response
{
    public class SaleDetailByIdResponseDto
    {
        public int ProductId { get; set; }
        public string? Image { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitSalePrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
