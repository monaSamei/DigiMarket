using App.Domain.Core.Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class ShopEntityConfigs : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.ToTable("Shops", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ShopDescription).HasMaxLength(1000);
            builder.Property(e => e.ShopTitle).HasMaxLength(150);

            builder.HasOne(d => d.Seller).WithMany(p => p.Shops)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shops_Sellers");
        
    }
    }
}