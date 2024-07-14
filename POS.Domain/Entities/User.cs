namespace POS.Domain.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UsersBranchOffices = new HashSet<UsersBranchOffice>();
        }

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public string? AuthType { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UsersBranchOffice> UsersBranchOffices { get; set; }
    }
}