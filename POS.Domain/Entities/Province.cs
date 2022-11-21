using System;
using System.Collections.Generic;

namespace POS.Domain.Entities
{
    public partial class Province
    {
        public Province()
        {
            Districts = new HashSet<District>();
        }

        public int ProvinceId { get; set; }
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int State { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<District> Districts { get; set; }
    }
}
