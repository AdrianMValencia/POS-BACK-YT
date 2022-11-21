using System;
using System.Collections.Generic;

namespace POS.Domain.Entities
{
    public partial class PurcharseDetail
    {
        public int PurcharseDetailId { get; set; }
        public int? PurcharseId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int? AuditUpdateUser { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
        public int? AuditDeleteUser { get; set; }
        public DateTime? AuditDeleteDate { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Purcharse? Purcharse { get; set; }
    }
}
