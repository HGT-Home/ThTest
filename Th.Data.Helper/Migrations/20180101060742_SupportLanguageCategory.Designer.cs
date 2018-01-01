﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Th.Data.Helper;

namespace Th.Data.Helper.Migrations
{
    [DbContext(typeof(ThDbContext))]
    [Migration("20180101060742_SupportLanguageCategory")]
    partial class SupportLanguageCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Th.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CreatedDate");

                    b.Property<byte[]>("ImageBinary")
                        .HasColumnName("ImageBinary");

                    b.Property<string>("ImagePath")
                        .HasColumnName("ImagePath")
                        .HasMaxLength(1024);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Th.Models.CategoryTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryId");

                    b.Property<string>("ColumnName")
                        .HasColumnName("ColumnName");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasColumnName("LanguageId");

                    b.Property<string>("Value")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryTranslations");
                });

            modelBuilder.Entity("Th.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("CountryId")
                        .HasColumnName("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Th.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Th.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .HasColumnName("Address");

                    b.Property<int>("CityId")
                        .HasColumnName("CityId");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Th.Models.Language", b =>
                {
                    b.Property<string>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CreatedDate");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasMaxLength(4000);

                    b.Property<bool>("IsDefault")
                        .HasColumnName("IsDefault");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(1024);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UpdatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Th.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderId");

                    b.Property<int>("CityId")
                        .HasColumnName("CityId");

                    b.Property<bool>("IsShipped")
                        .HasColumnName("IsShipped");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnName("OrderDate");

                    b.Property<string>("ShipAddress")
                        .HasColumnName("ShipAddress");

                    b.Property<string>("UserId")
                        .HasColumnName("UserId");

                    b.HasKey("OrderId");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Th.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderDetailId");

                    b.Property<int>("OrderId")
                        .HasColumnName("OrderId");

                    b.Property<decimal>("Price")
                        .HasColumnName("Price");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductId");

                    b.Property<decimal>("Quantity")
                        .HasColumnName("Quantity");

                    b.Property<decimal>("SubTotal")
                        .HasColumnName("SubTotal");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Th.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryId");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CreatedDate");

                    b.Property<byte[]>("ImageBinary")
                        .HasColumnName("ImageBinary");

                    b.Property<string>("ImagePath")
                        .HasColumnName("ImagePath")
                        .HasMaxLength(1024);

                    b.Property<string>("SupplierId")
                        .IsRequired()
                        .HasColumnName("SupplierId")
                        .HasMaxLength(50);

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("UnitPrice");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UpdatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("ViewCount")
                        .HasColumnName("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Th.Models.ProductAppreciation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CustomerId")
                        .HasColumnName("CustomerId");

                    b.Property<decimal>("Point")
                        .HasColumnName("Point");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductId");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UpdatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAppreciateions");
                });

            modelBuilder.Entity("Th.Models.ProductTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColumnName");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CreatedDate");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasColumnName("LanguageId")
                        .HasMaxLength(50);

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductId");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UpdatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnName("UpdatedDate");

                    b.Property<string>("Value")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTranslations");
                });

            modelBuilder.Entity("Th.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Th.Models.Supplier", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Logo")
                        .HasColumnName("Logo")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnName("Phone")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Th.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int?>("CustomerId")
                        .HasColumnName("CustomerId");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("EmployeeId")
                        .HasColumnName("EmployeeId");

                    b.Property<string>("FirstName")
                        .HasColumnName("FirstName");

                    b.Property<string>("FullName")
                        .HasColumnName("FullName");

                    b.Property<string>("LastName")
                        .HasColumnName("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Th.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Th.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Th.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Th.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Th.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Th.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Th.Models.CategoryTranslation", b =>
                {
                    b.HasOne("Th.Models.Category", "Category")
                        .WithMany("Translations")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Th.Models.City", b =>
                {
                    b.HasOne("Th.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Th.Models.Customer", b =>
                {
                    b.HasOne("Th.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Th.Models.Order", b =>
                {
                    b.HasOne("Th.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Th.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Th.Models.OrderDetail", b =>
                {
                    b.HasOne("Th.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Th.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Th.Models.Product", b =>
                {
                    b.HasOne("Th.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Th.Models.Supplier", "Suppiler")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Th.Models.ProductAppreciation", b =>
                {
                    b.HasOne("Th.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Th.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Th.Models.ProductTranslation", b =>
                {
                    b.HasOne("Th.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Th.Models.Product", "Product")
                        .WithMany("Translations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Th.Models.User", b =>
                {
                    b.HasOne("Th.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}
