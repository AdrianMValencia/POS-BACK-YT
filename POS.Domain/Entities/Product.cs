using System;
using System.Collections.Generic;

namespace POS.Domain.Entities
{
    public partial class Product
    {
        public Product()
        {
            PurcharseDetails = new HashSet<PurcharseDetail>();
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int ProductId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public decimal SellPrice { get; set; }
        public int CategoryId { get; set; }
        public int ProviderId { get; set; }
        public int State { get; set; }
        public int AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int? AuditUpdateUser { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
        public int? AuditDeleteUser { get; set; }
        public DateTime? AuditDeleteDate { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Provider Provider { get; set; } = null!;
        public virtual ICollection<PurcharseDetail> PurcharseDetails { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
