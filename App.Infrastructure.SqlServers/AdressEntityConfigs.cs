using App.Domain.Core.Customer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.SqlServers
{
    public class AdressEntityConfigs : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses", "dbo");
            builder.HasKey(e => e.Id).HasName("PK_Address");

            builder.Property(e => e.FullAddress).HasMaxLength(500);
            builder.Property(e => e.RegionTitle).HasMaxLength(250);
            builder.Property(e => e.Title).HasMaxLength(150);

            builder.HasOne(d => d.City).WithMany(p => p.Adresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Adresses_Cities");
        }
    }
}
