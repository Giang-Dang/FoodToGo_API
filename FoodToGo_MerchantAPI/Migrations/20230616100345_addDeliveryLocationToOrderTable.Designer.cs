﻿// <auto-generated />
using System;
using FoodToGo_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodToGo_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230616100345_addDeliveryLocationToOrderTable")]
    partial class addDeliveryLocationToOrderTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Ban", b =>
                {
                    b.Property<int>("BanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BanId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BanId");

                    b.HasIndex("UserId");

                    b.ToTable("Bans");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("int");

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("MerchantId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MenuItemImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.ToTable("MenuItemImages");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MenuItemRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("MenuItemRatings");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MenuItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MenuItemTypes");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Merchant", b =>
                {
                    b.Property<int>("MerchantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MerchantId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GeoLatitude")
                        .HasColumnType("float");

                    b.Property<double>("GeoLongitude")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MerchantId");

                    b.HasIndex("UserId");

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MerchantProfileImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("MerchantProfileImages");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MerchantRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<string>("FromUserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("ToMerchantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ToMerchantId");

                    b.ToTable("MerchantRatings");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.NormalOpenHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CloseTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SessionNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("NormalOpenHours");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.OnlineCustomerLocation", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double>("GeoLatitude")
                        .HasColumnType("float");

                    b.Property<double>("GeoLongitude")
                        .HasColumnType("float");

                    b.HasKey("CustomerId");

                    b.ToTable("OnlineCustomerLocations");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.OnlineShipperStatus", b =>
                {
                    b.Property<int>("ShipperId")
                        .HasColumnType("int");

                    b.Property<double>("GeoLatitude")
                        .HasColumnType("float");

                    b.Property<double>("GeoLongitude")
                        .HasColumnType("float");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.HasKey("ShipperId");

                    b.ToTable("OnlineShipperStatuses");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AppFee")
                        .HasColumnType("money");

                    b.Property<string>("CancellationReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeliveryCompletionTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("DeliveryLatitude")
                        .HasColumnType("float");

                    b.Property<double>("DeliveryLongitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("ETA")
                        .HasColumnType("datetime2");

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("money");

                    b.Property<DateTime>("PlacedTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PromotionDiscount")
                        .HasColumnType("money");

                    b.Property<int?>("PromotionId")
                        .HasColumnType("int");

                    b.Property<int?>("ShipperId")
                        .HasColumnType("int");

                    b.Property<decimal>("ShippingFee")
                        .HasColumnType("money");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cancelledBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MerchantId");

                    b.HasIndex("PromotionId");

                    b.HasIndex("ShipperId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SpecialInstruction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.OverrideOpenHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AltCloseTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AltOpenTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OverrideEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OverrideStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SessionNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("OverrideOpenHours");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("money");

                    b.Property<int>("DiscountCreatorMerchantId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountPercentage")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityLeft")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DiscountCreatorMerchantId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Shipper", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("VehicleNumberPlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.UserRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<string>("FromUserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.Property<string>("ToUserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ToUserId");

                    b.ToTable("UserRatings");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Ban", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Customer", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MenuItem", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.MenuItemType", "MenuItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodToGo_API.Models.DbEntities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItemType");

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MenuItemImage", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MenuItemRating", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodToGo_API.Models.DbEntities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodToGo_API.Models.DbEntities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Merchant", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MerchantProfileImage", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.MerchantRating", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.User", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodToGo_API.Models.DbEntities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodToGo_API.Models.DbEntities.Merchant", "ToMerchant")
                        .WithMany()
                        .HasForeignKey("ToMerchantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("Order");

                    b.Navigation("ToMerchant");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.NormalOpenHours", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.Merchant", "Merchant")
                        .WithMany("NormalOpenHoursList")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.OnlineCustomerLocation", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.OnlineShipperStatus", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.Shipper", "Shipper")
                        .WithMany()
                        .HasForeignKey("ShipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Order", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodToGo_API.Models.DbEntities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodToGo_API.Models.DbEntities.Promotion", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId");

                    b.HasOne("FoodToGo_API.Models.DbEntities.Shipper", "Shipper")
                        .WithMany()
                        .HasForeignKey("ShipperId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Customer");

                    b.Navigation("Merchant");

                    b.Navigation("Promotion");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.OrderDetail", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodToGo_API.Models.DbEntities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.OverrideOpenHours", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.Merchant", "Merchant")
                        .WithMany("OverrideOpenHoursList")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Promotion", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("DiscountCreatorMerchantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Shipper", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.UserRating", b =>
                {
                    b.HasOne("FoodToGo_API.Models.DbEntities.User", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodToGo_API.Models.DbEntities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodToGo_API.Models.DbEntities.User", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("Order");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Merchant", b =>
                {
                    b.Navigation("NormalOpenHoursList");

                    b.Navigation("OverrideOpenHoursList");
                });

            modelBuilder.Entity("FoodToGo_API.Models.DbEntities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
