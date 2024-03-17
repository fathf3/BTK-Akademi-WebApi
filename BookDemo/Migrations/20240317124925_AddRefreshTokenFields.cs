using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookDemo.Migrations
{
    public partial class AddRefreshTokenFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bfabdca-2f5c-4243-bc72-5a5f4298c670");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad92916c-5b89-46e8-9d8d-011b71b2fad9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec36a27e-a216-4a08-a567-d905c9a93ce6");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b212960b-8033-46f1-abea-9aea034b45be", "c5a0e877-887d-4c0e-b235-51597effe7ac", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c35d2ec0-e7a4-4f30-a340-e56a485e89da", "223e4ef4-be15-49ce-84dc-8465c6cfd112", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddfbff2e-6ef0-4a38-9ed6-e645fc6ac85d", "b31ac467-e395-4092-8bb9-faebe58fae39", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b212960b-8033-46f1-abea-9aea034b45be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c35d2ec0-e7a4-4f30-a340-e56a485e89da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddfbff2e-6ef0-4a38-9ed6-e645fc6ac85d");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4bfabdca-2f5c-4243-bc72-5a5f4298c670", "1bbc9910-7e40-455e-9403-c66d90dd6c56", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad92916c-5b89-46e8-9d8d-011b71b2fad9", "ee599271-3be7-40be-ac30-76fb74fb1c00", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec36a27e-a216-4a08-a567-d905c9a93ce6", "3c51d10d-81ec-4732-8a8d-d3b266c94878", "Admin", "ADMIN" });
        }
    }
}
