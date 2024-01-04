namespace POS.Domain.Entities
{
    public partial class PurcharseDetail
    {
        public int PurcharseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPurcharsePrice { get; set; }
        public decimal Total {  get; set; }

        public virtual Purcharse Purcharse { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}