using App.Domain.Core.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.SqlServers
{
    public class ProvinceEntityConfigs : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)

        {
            builder.ToTable("Provinces", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ProvinceName).HasMaxLength(100);

        }
    }
}