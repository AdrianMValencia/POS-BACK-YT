using System;
using System.Collections.Generic;

namespace POS.Domain.Entities
{
    public partial class Role
    {
        public Role()
        {
            MenuRoles = new HashSet<MenuRole>();
            UserRoles = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string? Description { get; set; }
        public int? State { get; set; }

        public virtual ICollection<MenuRole> MenuRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
