﻿// <auto-generated />
using System;
using HoneyZoneMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240415134337_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("78355d47-6040-4676-9972-ac8be4f19882"),
                            Name = "Honey"
                        },
                        new
                        {
                            Id = new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"),
                            Name = "Bee Pollen"
                        },
                        new
                        {
                            Id = new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"),
                            Name = "Beeswax"
                        },
                        new
                        {
                            Id = new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"),
                            Name = "Мerchandise"
                        });
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.DeliveryMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("DeliverMethods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fbf795c2-7516-4fd9-9979-c44bab57858c"),
                            Name = "Speedy"
                        },
                        new
                        {
                            Id = new Guid("37a420b3-6fd5-4922-a741-4298583813af"),
                            Name = "Econt"
                        });
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("83e83014-e29a-4d0e-9238-b52cf68bf6b7"),
                            ConcurrencyStamp = "e57840fd-1e5e-4e74-abaf-0f024d679d6b",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "36a51ff6-4883-4ecb-a05b-925c8cde19de",
                            Email = "administrator@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMINISTRATOR@GMAIL.COM",
                            NormalizedUserName = "FIRSTADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEDZtWFhj2eSAp9khqjH7vCVd88FUrLoAHyBbXWl/6w6UEw3YVmM99tHoPN0XOkqjlg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "BC48566F-9B56-44DB-A108-9851E717099C",
                            TwoFactorEnabled = false,
                            UserName = "FirstAdmin"
                        });
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.ImageUrl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ImageUrls");
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeliveryMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpectedDelivery")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("TotalSum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeliveryMethodId");

                    b.HasIndex("OrderDetailId");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.OrderProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Category Identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Product Description");

                    b.Property<double>("Discount")
                        .HasColumnType("float")
                        .HasComment("Product Discounted");

                    b.Property<bool>("IsDiscounted")
                        .HasColumnType("bit")
                        .HasComment("Has Discount Or Not");

                    b.Property<string>("MainImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Product Name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasComment("Product Price");

                    b.Property<string>("ProductAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Product Amount");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int")
                        .HasComment("Quantity Of The Product Available In Stock");

                    b.Property<int>("TimesOrdered")
                        .HasColumnType("int")
                        .HasComment("Number of times product has been ordered");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c7ecd019-40b1-47f3-89c4-67e3625f796b"),
                            CategoryId = new Guid("78355d47-6040-4676-9972-ac8be4f19882"),
                            Description = "Savor the golden goodness of our Sunflower honey. With its rich, floral aroma and robust flavor, this honey is a true delight for your taste buds. Harvested from the vibrant blooms of sunflowers, it boasts a smooth texture and a hint of nutty sweetness. Perfect for adding a touch of sunshine to your morning tea or drizzling over freshly baked goods. Experience the pure taste of nature with our Sunflower honey.",
                            Discount = 20.0,
                            IsDiscounted = true,
                            MainImageUrl = "bg honey2.png",
                            Name = "Sunflower Honey",
                            Price = 19.989999999999998,
                            ProductAmount = "800g",
                            QuantityInStock = 82,
                            TimesOrdered = 1
                        },
                        new
                        {
                            Id = new Guid("29d58e82-afc0-4433-9794-526ad44e6976"),
                            CategoryId = new Guid("78355d47-6040-4676-9972-ac8be4f19882"),
                            Description = "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.",
                            Discount = 0.0,
                            IsDiscounted = false,
                            MainImageUrl = "attachment_86137655.jpg",
                            Name = "Acacia honey",
                            Price = 25.989999999999998,
                            ProductAmount = "1kg",
                            QuantityInStock = 27,
                            TimesOrdered = 2
                        },
                        new
                        {
                            Id = new Guid("7ca61d2a-a232-4d85-94a1-518c17b3d849"),
                            CategoryId = new Guid("78355d47-6040-4676-9972-ac8be4f19882"),
                            Description = "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.",
                            Discount = 0.0,
                            IsDiscounted = false,
                            MainImageUrl = "black bg honey.png",
                            Name = "Manuka Honey",
                            Price = 18.989999999999998,
                            ProductAmount = "1kg",
                            QuantityInStock = 11,
                            TimesOrdered = 3
                        },
                        new
                        {
                            Id = new Guid("b4cccfd9-7b25-44fe-a785-1c0b286e0bff"),
                            CategoryId = new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"),
                            Description = "Discover the power of nature with our premium bee pollen product. Packed with nutrients and harvested from the finest sources, our bee pollen is a natural boost for your health and wellness routine. Simply sprinkle it on your favorite foods or blend it into smoothies for a delicious and nutritious addition. Energize your day the natural way with our bee pollen.",
                            Discount = 55.0,
                            IsDiscounted = true,
                            MainImageUrl = "bee-pollen-2549125_1280.jpg",
                            Name = "Wildflower Pollen",
                            Price = 55.990000000000002,
                            ProductAmount = "2kg",
                            QuantityInStock = 102,
                            TimesOrdered = 0
                        },
                        new
                        {
                            Id = new Guid("db09dc54-9636-4fd8-a6dd-fee9edfd739c"),
                            CategoryId = new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"),
                            Description = "Discover the versatile beauty of pure Beeswax. Known for its natural scent and golden hue, Beeswax is a versatile ingredient used in candles, skincare products, and more. Crafted by bees with precision, it offers a gentle, protective barrier for your skin and a warm, inviting glow when lit. Embrace the timeless elegance and natural charm of Beeswax in your daily rituals.",
                            Discount = 10.0,
                            IsDiscounted = true,
                            MainImageUrl = "Fresh-beeswax-for-hair-on-the-table.jpg",
                            Name = "Beeswax",
                            Price = 31.989999999999998,
                            ProductAmount = "900g",
                            QuantityInStock = 202,
                            TimesOrdered = 0
                        },
                        new
                        {
                            Id = new Guid("fb35088a-2a15-40d8-9207-0596b3c2cf99"),
                            CategoryId = new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"),
                            Description = "Made from durable materials, it securely holds your notes, photos, and grocery lists in place while adding a pop of personality to your fridge door. Bring a little bit of nature indoors and brighten up your kitchen with our Bee Fridge Magnet today!",
                            Discount = 0.0,
                            IsDiscounted = false,
                            MainImageUrl = "BeeMagnet.jpg",
                            Name = "Fridge Magnet",
                            Price = 1.99,
                            ProductAmount = "Single item",
                            QuantityInStock = 100,
                            TimesOrdered = 0
                        },
                        new
                        {
                            Id = new Guid("4d4c94dc-fe3a-46f0-b1c5-3c35048e959a"),
                            CategoryId = new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"),
                            Description = "Introducing our ceramic coffee cup adorned with small bees, adding a touch of nature to your morning routine. Crafted with care, each bee is hand-painted for a unique and charming design. Enjoy your favorite brew in style and bring the beauty of the outdoors to your daily cup of coffee.",
                            Discount = 0.0,
                            IsDiscounted = false,
                            MainImageUrl = "coffee-cup-bees.jpg",
                            Name = "Coffee Cup",
                            Price = 2.9900000000000002,
                            ProductAmount = "Single item",
                            QuantityInStock = 50,
                            TimesOrdered = 0
                        });
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa54a723-dd2c-4232-bee5-7be89494f178"),
                            Name = "Confirmed"
                        },
                        new
                        {
                            Id = new Guid("efdf191d-7ffb-4c7c-a917-ec030a7cba2a"),
                            Name = "Pending"
                        },
                        new
                        {
                            Id = new Guid("ccfce986-e38a-4c30-b8b0-af4e50c1f931"),
                            Name = "Sent"
                        },
                        new
                        {
                            Id = new Guid("ff2ccc15-cb3c-42ed-93e2-b6d8ac8e6946"),
                            Name = "Delivered"
                        },
                        new
                        {
                            Id = new Guid("caa61a04-b961-4aa5-9851-1226ebeea072"),
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
                            RoleId = new Guid("83e83014-e29a-4d0e-9238-b52cf68bf6b7")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.ImageUrl", b =>
                {
                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.Order", b =>
                {
                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels.ApplicationUser", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.DeliveryMethod", "DeliveryMethod")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.OrderDetail", "OrderDetail")
                        .WithMany()
                        .HasForeignKey("OrderDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("DeliveryMethod");

                    b.Navigation("OrderDetail");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.OrderProduct", b =>
                {
                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.Product", b =>
                {
                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.DeliveryMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
