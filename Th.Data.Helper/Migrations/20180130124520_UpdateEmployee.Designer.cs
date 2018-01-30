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
    [Migration("20180130124520_UpdateEmployee")]
    partial class UpdateEmployee
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
                        .HasColumnName("ColumnName")
                        .HasMaxLength(128);

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasColumnName("LanguageId")
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LanguageId");

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

            modelBuilder.Entity("Th.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .HasColumnName("Address")
                        .HasMaxLength(1024);

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasMaxLength(256);

                    b.Property<string>("Facebook")
                        .HasColumnName("Facebook")
                        .HasMaxLength(1024);

                    b.Property<string>("Hotline")
                        .HasColumnName("Hotline")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDefault")
                        .HasColumnName("IsDefault");

                    b.Property<string>("Latitude")
                        .HasColumnName("Latitude");

                    b.Property<string>("Longitude")
                        .HasColumnName("Longitude");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(256);

                    b.Property<string>("Phone")
                        .HasColumnName("Phone")
                        .HasMaxLength(50);

                    b.Property<string>("Twitter")
                        .HasColumnName("Twitter")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("Companies");
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

                    b.Property<string>("Username")
                        .HasColumnName("Username")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Th.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasMaxLength(4000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Th.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .HasColumnName("Address")
                        .HasMaxLength(1024);

                    b.Property<string>("CardIdNumber")
                        .HasColumnName("CardIdNumber")
                        .HasMaxLength(16);

                    b.Property<int>("DepartmentId")
                        .HasColumnName("DepartmentId");

                    b.Property<byte[]>("ImageBinary")
                        .HasColumnName("ImageBinary");

                    b.Property<string>("ImagesPath")
                        .HasColumnName("ImagesPath")
                        .HasMaxLength(256);

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PhoneNumber")
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
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

                    b.Property<int?>("ProductStatusId")
                        .HasColumnName("ProductStatusId");

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

                    b.HasIndex("ProductStatusId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Th.Models.ProductRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Comment")
                        .HasColumnName("Comment")
                        .HasMaxLength(2048);

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

                    b.ToTable("ProductRates");
                });

            modelBuilder.Entity("Th.Models.ProductStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CreatedDate");

                    b.Property<bool>("IsStop")
                        .HasColumnName("IsStop");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UpdatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("ProductStatuses");
                });

            modelBuilder.Entity("Th.Models.ProductStatusTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("ColumnName")
                        .HasColumnName("ColumnName")
                        .HasMaxLength(128);

                    b.Property<string>("LanguageId")
                        .HasColumnName("LanguageId")
                        .HasMaxLength(50);

                    b.Property<int>("ProductStatusId")
                        .HasColumnName("ProductStatusId");

                    b.Property<string>("Value")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductStatusId");

                    b.ToTable("ProductStatusTranslations");
                });

            modelBuilder.Entity("Th.Models.ProductTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColumnName")
                        .HasColumnName("ColumnName")
                        .HasMaxLength(128);

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

                    b.Property<string>("Address")
                        .HasColumnName("Address")
                        .HasMaxLength(1024);

                    b.Property<int>("CityId")
                        .HasColumnName("CityId");

                    b.Property<int>("CountryId")
                        .HasColumnName("CountryId");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CreatedDate");

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasMaxLength(1024);

                    b.Property<string>("Fax")
                        .HasColumnName("Fax")
                        .HasMaxLength(50);

                    b.Property<string>("Logo")
                        .HasColumnName("Logo")
                        .HasMaxLength(1024);

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(1024);

                    b.Property<string>("Phone")
                        .HasColumnName("Phone")
                        .HasMaxLength(50);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UpdatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UpdatedDate");

                    b.Property<string>("WebSiste")
                        .HasColumnName("WebSiste")
                        .HasMaxLength(256);

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
                        .HasColumnName("FirstName")
                        .HasMaxLength(128);

                    b.Property<string>("FullName")
                        .HasColumnName("FullName")
                        .HasMaxLength(256);

                    b.Property<string>("Gender")
                        .HasColumnName("Gender")
                        .HasMaxLength(64);

                    b.Property<string>("LastName")
                        .HasColumnName("LastName")
                        .HasMaxLength(128);

                    b.Property<string>("Locale")
                        .HasColumnName("Locale")
                        .HasMaxLength(128);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(128);

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

                    b.HasIndex("EmployeeId");

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

                    b.HasOne("Th.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
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

            modelBuilder.Entity("Th.Models.Employee", b =>
                {
                    b.HasOne("Th.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
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

                    b.HasOne("Th.Models.ProductStatus", "ProductStatus")
                        .WithMany("Products")
                        .HasForeignKey("ProductStatusId");

                    b.HasOne("Th.Models.Supplier", "Suppiler")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Th.Models.ProductRate", b =>
                {
                    b.HasOne("Th.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Th.Models.Product", "Product")
                        .WithMany("Rates")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Th.Models.ProductStatusTranslation", b =>
                {
                    b.HasOne("Th.Models.ProductStatus", "ProductStatus")
                        .WithMany("Translations")
                        .HasForeignKey("ProductStatusId")
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
                        .WithMany("Users")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Th.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}
