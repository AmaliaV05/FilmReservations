using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmReservation.Data.Migrations
{
    public partial class UpdatePropertyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HallsNumber",
                table: "Cinemas",
                newName: "TotalHalls");

            migrationBuilder.RenameColumn(
                name: "SeatsNumber",
                table: "CinemaHalls",
                newName: "TotalSeats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalHalls",
                table: "Cinemas",
                newName: "HallsNumber");

            migrationBuilder.RenameColumn(
                name: "TotalSeats",
                table: "CinemaHalls",
                newName: "SeatsNumber");
        }
    }
}
