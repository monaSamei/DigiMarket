using App.Domain.Core.Customer.Entities;
using App.Domain.Core.Seller.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class CommentEntityConfigs : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments", "dbo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(s => s.Seller).WithMany(c => c.Comments)
                 .HasForeignKey(d => d.SellerId)
                 .HasConstraintName("FK_Comments_Sellers");

            builder.HasOne(d => d.Customer).WithMany(c=>c.Comments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Comments_Customers");
        }
    }
}