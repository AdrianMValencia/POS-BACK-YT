namespace POS.Application.Dtos.Purcharse.Response
{
    public class PurcharseResponseDto
    {
        public int PurcharseId { get; set; }
        public string? Provider {  get; set; }
        public string? Warehouse {  get; set; }
        public decimal TotalAmount {  get; set; }
        public DateTime DateOfPurcharse { get; set; }
    }
}