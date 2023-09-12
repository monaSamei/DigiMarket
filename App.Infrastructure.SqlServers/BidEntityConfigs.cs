using App.Domain.Core.Seller.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class BidEntityConfigs : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.ToTable("Bids", "dbo");
            builder.Property(e => e.SellerComment).HasMaxLength(500);

            builder.HasOne(d => d.Customer).WithMany(p => p.Bids)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Bids_Customers");

            builder.HasOne(d => d.Factor).WithMany(p => p.Bids)
                .HasForeignKey(d => d.FactorId)
                .HasConstraintName("FK_Bids_Factors");

            builder.HasOne(d => d.Seller).WithMany(p => p.Bids)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_Bids_Sellers");

        }
    }
}
