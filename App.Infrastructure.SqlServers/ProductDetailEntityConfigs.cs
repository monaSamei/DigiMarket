using App.Domain.Core.Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class ProductDetailEntityConfigs : IEntityTypeConfiguration<ProductDetail>
    {
          public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("ProductDetails", "dbo");
            builder.Property(e => e.Title).HasMaxLength(150);
            builder.Property(e => e.Description).HasMaxLength(1000);

            builder.HasOne(d => d.Product).WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductDetails_Products");
        }
    }
}