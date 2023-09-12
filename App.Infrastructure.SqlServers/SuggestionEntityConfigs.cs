using App.Domain.Core.Customer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class SuggestionEntityConfigs : IEntityTypeConfiguration<Suggestion>
    {
        public void Configure(EntityTypeBuilder<Suggestion> builder)
        {
            builder.ToTable("Suggestions", "dbo");
            builder.HasKey(e => e.Id).HasName("PK_Orders");

            builder.Property(e => e.Description).HasMaxLength(1000);

            builder.HasOne(d => d.Bid).WithMany(p => p.Suggestions)
                .HasForeignKey(d => d.BidId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Suggestions_Bids");

            builder.HasOne(d => d.Product).WithMany(p => p.Suggestions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Suggestions_Products");

        }
    }
}