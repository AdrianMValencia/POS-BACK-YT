namespace POS.Domain.Entities
{
    public partial class Product : BaseEntity
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public string? Image { get; set; }
        public decimal UnitSalePrice {  get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProductStock> ProductStocks { get; set; } = null!;
    }
}