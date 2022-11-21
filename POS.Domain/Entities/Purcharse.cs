using System;
using System.Collections.Generic;

namespace POS.Domain.Entities
{
    public partial class Purcharse
    {
        public Purcharse()
        {
            PurcharseDetails = new HashSet<PurcharseDetail>();
        }

        public int PurcharseId { get; set; }
        public int? ProviderId { get; set; }
        public int? UserId { get; set; }
        public DateTime? PurcharseDate { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Total { get; set; }
        public int? State { get; set; }
        public int AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int? AuditUpdateUser { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
        public int? AuditDeleteUser { get; set; }
        public DateTime? AuditDeleteDate { get; set; }

        public virtual Provider? Provider { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<PurcharseDetail> PurcharseDetails { get; set; }
    }
}
