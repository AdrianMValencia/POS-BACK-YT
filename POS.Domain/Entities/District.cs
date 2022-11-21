using System;
using System.Collections.Generic;

namespace POS.Domain.Entities
{
    public partial class District
    {
        public District()
        {
            BranchOffices = new HashSet<BranchOffice>();
            Businesses = new HashSet<Business>();
        }

        public int DistrictId { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; } = null!;
        public int State { get; set; }

        public virtual Province Province { get; set; } = null!;
        public virtual ICollection<BranchOffice> BranchOffices { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}
