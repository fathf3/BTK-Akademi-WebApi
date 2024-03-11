using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookDemo.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
