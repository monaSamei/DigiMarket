using App.Domain.Core.Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class ProductEntityConfigs : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products","dbo");
            builder.Property(e => e.Title).HasMaxLength(150);

            builder.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_ProductCategory");

            //builder .HasOne(d => d.Picture).WithMany(p => p.Products)
            //    .HasForeignKey(d => d.PictureId)
            //    .HasConstraintName("FK_Products_Pictures");

            builder.HasOne(d => d.Shop).WithMany(p => p.Products)
                .HasForeignKey(d => d.ShopId)
                .HasConstraintName("FK_Products_Shops");

        }
    }
}