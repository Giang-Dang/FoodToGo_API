﻿using FoodToGo_API.Models.DbEntities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FoodToGo_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<MenuItemType> MenuItemTypes { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemImage> MenuItemImages { get; set; }
        public DbSet<OnlineCustomerLocation> OnlineCustomerLocations { get; set; }
        public DbSet<OnlineShipperStatus> OnlineShipperStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<NormalOpenHours> NormalOpenHours { get; set; }
        public DbSet<OverrideOpenHours> OverrideOpenHours { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<MenuItemRating> MenuItemRatings { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<MerchantProfileImage> MerchantProfileImages { get; set; }
        public DbSet<MerchantRating> MerchantRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //1-n Order -> OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(order => order.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            //1-n Merchant -> NormalOpenHours
            modelBuilder.Entity<NormalOpenHours>()
                .HasOne(e => e.Merchant)
                .WithMany(m => m.NormalOpenHoursList)
                .HasForeignKey(e => e.MerchantId);

            //1-n Merchant -> OverrideOpenHours
            modelBuilder.Entity<OverrideOpenHours>()
                .HasOne(e => e.Merchant)
                .WithMany(m => m.OverrideOpenHoursList)
                .HasForeignKey(e => e.MerchantId);

            modelBuilder.Entity<MerchantRating>()
                .ToTable(tb => tb.HasTrigger("updateMerchantRating"));

            modelBuilder.Entity<UserRating>()
                .ToTable(tb => tb.HasTrigger("updateUserRating"));

            modelBuilder.Entity<MenuItemRating>()
                .ToTable(tb => tb.HasTrigger("updateMenuItemRating"));

            //decimal => ColumnType: money
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(decimal))
                    {
                        property.SetColumnType("money");
                    }
                }
            }
        }
    }
}
