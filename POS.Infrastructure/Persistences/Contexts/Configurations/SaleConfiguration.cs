using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistences.Contexts.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("SaleId");

            builder.Property(e => e.VoucherNumber)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.Igv).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
        }
    }
}