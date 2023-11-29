namespace POS.Domain.Entities
{
    public class Warehouse : BaseEntity
    {
        public string? Name {  get; set; }
        public virtual ICollection<ProductStock> ProductStocks { get; set; } = null!;
    }
}