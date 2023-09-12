using App.Domain.Core.Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class PictureEntityConfigs : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Pictures", "dbo");
            builder.Property(e => e.PictureTypes).HasMaxLength(50);
            builder.Property(e => e.PictureUrl).HasMaxLength(200);
        }
    }
}