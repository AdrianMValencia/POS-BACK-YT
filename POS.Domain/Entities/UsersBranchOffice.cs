using System;
using System.Collections.Generic;

namespace POS.Domain.Entities
{
    public partial class UsersBranchOffice
    {
        public int UserBranchOfficeId { get; set; }
        public int? BranchOfficeId { get; set; }
        public int? UserId { get; set; }
        public int? State { get; set; }

        public virtual BranchOffice? BranchOffice { get; set; }
        public virtual User? User { get; set; }
    }
}
