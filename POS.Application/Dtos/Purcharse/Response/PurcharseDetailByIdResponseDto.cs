namespace POS.Application.Dtos.Purcharse.Response
{
    public class PurcharseDetailByIdResponseDto
    {
        public int ProductId { get; set; }
        public string? Image {  get; set; }
        public string? Code {  get; set; }
        public string? Name { get; set; }
        public int Quantity {  get; set; }
        public decimal UnitPurcharsePrice {  get; set; }
        public decimal TotalAmount {  get; set; }
    }
}