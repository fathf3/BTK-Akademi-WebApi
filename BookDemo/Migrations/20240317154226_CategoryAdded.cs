using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookDemo.Migrations
{
    public partial class CategoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "003971f1-4c68-47ef-9689-a7c8bd756ba0", "d626c569-1af2-4aae-8f14-03820a182943", "User", "USER" },
                    { "03e55699-d8d7-4104-b15d-f504cbf4558d", "1704670e-cc09-4e73-935a-4a0570505a74", "Editor", "EDITOR" },
                    { "77ec8891-6a68-4799-a81f-4c625563102c", "bb315c74-5abf-4869-a3d0-eb77401197ca", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Network" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "003971f1-4c68-47ef-9689-a7c8bd756ba0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03e55699-d8d7-4104-b15d-f504cbf4558d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77ec8891-6a68-4799-a81f-4c625563102c");

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
    }
}
