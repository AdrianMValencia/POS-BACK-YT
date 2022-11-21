using System;
using System.Collections.Generic;

namespace POS.Domain.Entities
{
    public partial class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int SaleId { get; set; }
        public int? ClientId { get; set; }
        public int? UserId { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Total { get; set; }
        public int? State { get; set; }
        public int AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int? AuditUpdateUser { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
        public int? AuditDeleteUser { get; set; }
        public DateTime? AuditDeleteDate { get; set; }

        public virtual Client? Client { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
