namespace POS.Application.Dtos.Purcharse.Request
{
    public class PurcharseRequestDto
    {
        public string? Observation {  get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv {  get; set; }
        public decimal TotalAmount { get; set; }
        public int WarehouseId {  get; set; }
        public int ProviderId { get; set; }
        public ICollection<PurcharseDetailRequestDto> PurcharseDetails { get; set; } = null!;
    }
}
