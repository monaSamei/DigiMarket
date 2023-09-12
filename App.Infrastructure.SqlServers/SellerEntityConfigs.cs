using App.Domain.Core.Seller.Entities;
using App.Domain.Core.Customer;
using App.Domain.Core.Customer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class SellerEntityConfigs : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Medal)
                .HasMaxLength(10)
                .IsFixedLength();
            builder.HasOne(e => e.User).WithOne();
           

        }
    }
}