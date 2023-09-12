using App.Domain.Core.BaseData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.SqlServers
{
    public class CityEntityConfigs : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities", "dbo");
            builder.Property(e => e.CityName).HasMaxLength(100);

            builder.HasOne(d => d.Province).WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK_Cities_Provinces");
        }
    }
}
