using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Th.Data.Helper.Migrations
{
    public partial class AddLanguageUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranlations_Languages_Language",
                table: "ProductTranlations");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "ProductTranlations",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTranlations_Language",
                table: "ProductTranlations",
                newName: "IX_ProductTranlations_LanguageId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Languages",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Languages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Languages",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Languages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranlations_Languages_LanguageId",
                table: "ProductTranlations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranlations_Languages_LanguageId",
                table: "ProductTranlations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Languages");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "ProductTranlations",
                newName: "Language");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTranlations_LanguageId",
                table: "ProductTranlations",
                newName: "IX_ProductTranlations_Language");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranlations_Languages_Language",
                table: "ProductTranlations",
                column: "Language",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
