﻿// <auto-generated />
using System;
using HoneyZoneMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("7b72a44a-8551-4403-8e4f-21331c871052"),
                            Name = "Speedy"
                        },
                        new
                        {
                            Id = new Guid("30a57e13-da8e-4237-8193-2fa392117781"),
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
                            ConcurrencyStamp = "1d88b7cd-1a8b-4879-81c5-9620fdf8451d",
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
                            ConcurrencyStamp = "c98912ef-c052-4689-85eb-caf8ef49fd40",
                            Email = "administrator@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMINISTRATOR@GMAIL.COM",
                            NormalizedUserName = "FIRSTADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEORQhWYCFmjaJu38IK3EZERtBeh5H/pLaUEggPvWQwsiw51HP/h3STbJ974lJHcrOw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "C8FCBFBC-2436-4CCA-8E51-1508F646856C",
                            TwoFactorEnabled = false,
                            UserName = "FirstAdmin"
                        });
                });

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.ImageUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<Guid>("StateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("TotalSum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeliveryMethodId");

                    b.HasIndex("OrderDetailId");

                    b.HasIndex("StateId");

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

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

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
                            Id = new Guid("9dde1d9d-77d2-4254-bf26-71cfa42ea43b"),
                            CategoryId = new Guid("78355d47-6040-4676-9972-ac8be4f19882"),
                            Description = "Savor the golden goodness of our Sunflower honey. With its rich, floral aroma and robust flavor, this honey is a true delight for your taste buds. Harvested from the vibrant blooms of sunflowers, it boasts a smooth texture and a hint of nutty sweetness. Perfect for adding a touch of sunshine to your morning tea or drizzling over freshly baked goods. Experience the pure taste of nature with our Sunflower honey.",
                            Discount = 20.0,
                            IsDiscounted = true,
                            MainImageUrl = "bg honey2.png",
                            Name = "Sunflower Honey",
                            Price = 19.989999999999998,
                            ProductAmount = "800g",
                            QuantityInStock = 82,
                            TimesOrdered = 0
                        },
                        new
                        {
                            Id = new Guid("09087007-c629-4557-9fb6-89e0a7cbd749"),
                            CategoryId = new Guid("78355d47-6040-4676-9972-ac8be4f19882"),
                            Description = "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.",
                            Discount = 0.0,
                            IsDiscounted = false,
                            MainImageUrl = "attachment_86137655.jpg",
                            Name = "Acacia honey",
                            Price = 25.989999999999998,
                            ProductAmount = "1kg",
                            QuantityInStock = 27,
                            TimesOrdered = 0
                        },
                        new
                        {
                            Id = new Guid("76cff94a-2e4f-4ceb-80e7-25756c088d3f"),
                            CategoryId = new Guid("78355d47-6040-4676-9972-ac8be4f19882"),
                            Description = "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.",
                            Discount = 0.0,
                            IsDiscounted = false,
                            MainImageUrl = "black bg honey.png",
                            Name = "Manuka Honey",
                            Price = 18.989999999999998,
                            ProductAmount = "1kg",
                            QuantityInStock = 11,
                            TimesOrdered = 0
                        },
                        new
                        {
                            Id = new Guid("99def0eb-beb9-41ad-9ebb-474bd012cfec"),
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
                            Id = new Guid("7073fe9d-72ea-4d51-b1ac-b8a1c612c3cd"),
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
                            Id = new Guid("4ef1ad95-25bb-4067-96df-501edc0312bb"),
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
                            Id = new Guid("3149a140-b99b-4ade-b506-13b02b2e95f0"),
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

            modelBuilder.Entity("HoneyZoneMvc.Infrastructure.Data.Models.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80c276fe-bc40-42cd-a249-ef2e0f126de5"),
                            Name = "Confirmed"
                        },
                        new
                        {
                            Id = new Guid("0bbe8121-9526-469b-8369-e71b2dbfcdaa"),
                            Name = "Pending"
                        },
                        new
                        {
                            Id = new Guid("cadd0870-29b8-4e0e-a867-600a2f0ae59e"),
                            Name = "Sent"
                        },
                        new
                        {
                            Id = new Guid("ebda945d-5cfb-4aec-a01c-c644e0c5fc5c"),
                            Name = "Delivered"
                        },
                        new
                        {
                            Id = new Guid("31ad6091-3a84-45b9-ac48-e65b18d8f658"),
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

                    b.HasOne("HoneyZoneMvc.Infrastructure.Data.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("DeliveryMethod");

                    b.Navigation("OrderDetail");

                    b.Navigation("State");
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
