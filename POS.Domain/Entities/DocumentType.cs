namespace POS.Domain.Entities
{
    public partial class DocumentType : BaseEntity
    {
        public DocumentType()
        {
            Clients = new HashSet<Client>();
            Providers = new HashSet<Provider>();
        }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Abbreviation { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
    }
}