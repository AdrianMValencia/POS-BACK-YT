using System;
using System.Collections.Generic;

namespace POS.Domain.Entities
{
    public partial class Business
    {
        public Business()
        {
            BranchOffices = new HashSet<BranchOffice>();
        }

        public int BusinessId { get; set; }
        public string Code { get; set; } = null!;
        public string Ruc { get; set; } = null!;
        public string BusinessName { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public int DistrictId { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public string Phone { get; set; } = null!;
        public string? Vision { get; set; }
        public string? Mision { get; set; }
        public int State { get; set; }

        public virtual District District { get; set; } = null!;
        public virtual ICollection<BranchOffice> BranchOffices { get; set; }
    }
}
