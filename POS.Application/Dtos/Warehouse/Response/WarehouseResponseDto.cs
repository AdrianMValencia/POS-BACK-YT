namespace POS.Application.Dtos.Warehouse.Response
{
    public class WarehouseResponseDto
    {
        public int WarehouseId { get; set; }
        public string? Name { get; set; }
        public DateTime AuditCreateDate {  get; set; }
        public int State {  get; set; }
        public string? StateWarehouse {  get; set; }
    }
}