namespace POS.Application.Dtos.Sale.Response
{
    public class SaleByIdResponseDto
    {
        public int SaleId { get; set; }
        public string VoucherNumber { get; set; } = null!;
        public string? Observation { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal TotalAmount { get; set; }
        public int VoucherDocumentTypeId { get; set; }
        public int WarehouseId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateOfSale { get; set; }
        public ICollection<SaleDetailByIdResponseDto> SaleDetails { get; set; } = null!;
    }
}
