namespace POS.Domain.Entities
{
    public class ProductStock
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int CurrentStock {  get; set; }
        public decimal PurchasePrice {  get; set; }
        public Product Product { get; set; } = null!;
        public Warehouse Warehouse { get; set;} = null!;
    }
}