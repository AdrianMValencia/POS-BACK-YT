namespace POS.Domain.Entities
{
    public partial class Provider : BaseEntity
    {
        public Provider()
        {
            Products = new HashSet<Product>();
            Purcharses = new HashSet<Purcharse>();
        }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int DocumentTypeId { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string? Address { get; set; }
        public string Phone { get; set; } = null!;

        public virtual DocumentType DocumentType { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Purcharse> Purcharses { get; set; }
    }
}