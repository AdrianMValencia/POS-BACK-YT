namespace POS.Domain.Entities
{
    public partial class Purcharse : BaseEntity
    {
        public string? Observation {  get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv {  get; set; }
        public decimal TotalAmount {  get; set; }
        public int WarehouseId {  get; set; }
        public int ProviderId { get; set; }

        public virtual ICollection<PurcharseDetail> PurcharseDetails { get; set; } = null!;
        public virtual Warehouse Warehouse { get; set; } = null!;
        public virtual Provider? Provider { get; set; } = null!;
    }
}