namespace POS.Application.Dtos.Sale.Request
{
    public class SaleRequestDto
    {
        public string VoucherNumber { get; set; } = null!;
        public string? Observation { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal TotalAmount { get; set; }
        public int VoucherDocumentTypeId { get; set; }
        public int WarehouseId { get; set; }
        public int ClientId { get; set; }
        public ICollection<SaleDetailRequestDto> SaleDetails { get; set; }
    }
}
