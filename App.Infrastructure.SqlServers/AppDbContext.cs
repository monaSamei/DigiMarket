using System;
using System.Collections.Generic;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Customer;
using App.Domain.Core.Customer.Entities;
using App.Domain.Core.Seller.Entities;
using App.Domain.Core.Shop.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.SqlServers
{
    public partial class AppDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bid> Bids { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        //public virtual DbSet<Domain.Core.Seller.Entities.Comment> Comments { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Suggestion> Suggestions { get; set; }

        public virtual DbSet<Factor> Factors { get; set; }


        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<ProductDetail> ProductDetails { get; set; }

        public virtual DbSet<Province> Provinces { get; set; }

        public virtual DbSet<Seller> Sellers { get; set; }

        public virtual DbSet<Shop> Shops { get; set; }

        public virtual DbSet<Site> Sites { get; set; }

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseSqlServer("Server=.;Database=MarketDb;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdressEntityConfigs());
            modelBuilder.ApplyConfiguration(new BidEntityConfigs());
            modelBuilder.ApplyConfiguration(new CityEntityConfigs());
            modelBuilder.ApplyConfiguration(new CommentEntityConfigs());
            modelBuilder.ApplyConfiguration(new CommentEntityConfigs());
            modelBuilder.ApplyConfiguration(new SuggestionEntityConfigs());
            modelBuilder.ApplyConfiguration(new FactorEntityConfigs());
            modelBuilder.ApplyConfiguration(new PictureEntityConfigs());
            modelBuilder.ApplyConfiguration(new ProductEntityConfigs());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfigs());
            modelBuilder.ApplyConfiguration(new ProductDetailEntityConfigs());
            modelBuilder.ApplyConfiguration(new ProvinceEntityConfigs());
            modelBuilder.ApplyConfiguration(new SellerEntityConfigs());
            modelBuilder.ApplyConfiguration(new ShopEntityConfigs());

            //modelBuilder.Entity<Customer>(entity =>
            //{
            //    entity.HasOne(e => e.User).WithOne();
            //});

            //modelBuilder.Entity<IdentityUser<Guid>>(entity =>
            //{
            //    entity.HasOne<Customer>().WithOne(e => e.User);
            //}); ;


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}