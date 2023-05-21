using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistences.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("UserId");

            builder.Property(e => e.Email).IsUnicode(false);

            builder.Property(e => e.Image).IsUnicode(false);

            builder.Property(e => e.Password).IsUnicode(false);

            builder.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.AuthType)
                .HasMaxLength(15)
                .IsUnicode(false);
        }
    }
}