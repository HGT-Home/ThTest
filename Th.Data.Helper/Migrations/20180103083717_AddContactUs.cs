using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Th.Data.Helper.Migrations
{
    public partial class AddContactUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStatusTranslation_ProductStatuses_ProductStatusId",
                table: "ProductStatusTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStatusTranslation",
                table: "ProductStatusTranslation");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "ProductStatusTranslation",
                newName: "ProductStatusTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStatusTranslation_ProductStatusId",
                table: "ProductStatusTranslations",
                newName: "IX_ProductStatusTranslations_ProductStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStatusTranslations",
                table: "ProductStatusTranslations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 1024, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStatusTranslations_ProductStatuses_ProductStatusId",
                table: "ProductStatusTranslations",
                column: "ProductStatusId",
                principalTable: "ProductStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStatusTranslations_ProductStatuses_ProductStatusId",
                table: "ProductStatusTranslations");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStatusTranslations",
                table: "ProductStatusTranslations");

            migrationBuilder.RenameTable(
                name: "ProductStatusTranslations",
                newName: "ProductStatusTranslation");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStatusTranslations_ProductStatusId",
                table: "ProductStatusTranslation",
                newName: "IX_ProductStatusTranslation_ProductStatusId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStatusTranslation",
                table: "ProductStatusTranslation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStatusTranslation_ProductStatuses_ProductStatusId",
                table: "ProductStatusTranslation",
                column: "ProductStatusId",
                principalTable: "ProductStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
