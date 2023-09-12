using App.Domain.Core.Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class CategoryEntityConfigs : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "dbo");


            builder.Property(e => e.Title).HasMaxLength(150);
        }
    }
}