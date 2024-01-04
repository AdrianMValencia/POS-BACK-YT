namespace POS.Application.Dtos.Purcharse.Response
{
    public class PurcharseByIdResponseDto
    {
        public int PurcharseId {  get; set; }
        public string? Observation { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv {  get; set; }
        public decimal TotalAmount {  get; set; }
        public int ProviderId {  get; set; }
        public int WarehouseId { get; set; }
        public ICollection<PurcharseDetailByIdResponseDto> PurcharseDetails { get; set; } = null!;
    }
}
