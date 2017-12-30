using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Th.Data.Helper.Migrations
{
    public partial class AddProductLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Name = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranlations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Language = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranlations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTranlations_Languages_Language",
                        column: x => x.Language,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTranlations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranlations_Language",
                table: "ProductTranlations",
                column: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranlations_ProductId",
                table: "ProductTranlations",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTranlations");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
