using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmReservation.Data.Migrations
{
    public partial class UpdateRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6facc23c-e274-41b1-9ac1-8efb7b71689d");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6facc23c-e274-41b1-9ac1-8efb7b71689d", "c4b1fccd-35d0-455a-b28e-3f66293c68e6", "Employee", "EMPLOYEE" });
        }
    }
}
