using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmReservation.Migrations
{
    public partial class UpdateRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f35318d-556b-4014-8891-a5d907babdca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "147cfd4a-f4ea-49ba-999f-1006e346af53");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b18956a-e040-4fd0-8a9e-5e6f0946a4fe", "7551a98b-46f3-48d7-b9a3-4d27603f313b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6facc23c-e274-41b1-9ac1-8efb7b71689d", "c4b1fccd-35d0-455a-b28e-3f66293c68e6", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee2a151e-99b3-4305-a4ef-d25a9320908b", "fa893815-597a-4347-b5e8-b91a4ff91988", "Client", "CLIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b18956a-e040-4fd0-8a9e-5e6f0946a4fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6facc23c-e274-41b1-9ac1-8efb7b71689d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee2a151e-99b3-4305-a4ef-d25a9320908b");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "147cfd4a-f4ea-49ba-999f-1006e346af53", "b656def7-f77f-41f5-b156-32d3f648dd06", "UserRole", "AppUser", "APPUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "0f35318d-556b-4014-8891-a5d907babdca", "499fbc38-b85c-4090-8678-e7be00b02f44", "UserRole", "AppAdmin", "APPADMIN" });
        }
    }
}
