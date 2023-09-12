using App.Domain.Core.Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class FactorEntityConfigs : IEntityTypeConfiguration<Factor>
    {
        public void Configure(EntityTypeBuilder<Factor> builder)
        {
            builder.ToTable("Factors", "dbo");
            builder.HasOne(d => d.Customer).WithMany(p => p.Factors)
               .HasForeignKey(d => d.CustomerId)
               .HasConstraintName("FK_Factors_Customers");

            builder.HasOne(d => d.Seller).WithMany(p => p.Factors)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_Factors_Sellers");

        }
    }
}