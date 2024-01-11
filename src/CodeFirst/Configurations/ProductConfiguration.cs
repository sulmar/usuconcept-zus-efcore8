using Microsoft.EntityFrameworkCore;
using CodeFirst.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
           .Property(p => p.Barcode)
           .HasMaxLength(128)
           .IsUnicode(false);

        builder
            .HasIndex(p => p.Barcode)
            .IsUnique();
    }
}
