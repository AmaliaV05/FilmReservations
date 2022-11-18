using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmReservation.Migrations
{
    public partial class UpdateFilmChangeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmReservation");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "Watched",
                table: "Films",
                newName: "Cast");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Films",
                newName: "Language");

            migrationBuilder.AddColumn<int>(
                name: "AgeRestriction",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Films",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_ReservationId",
                table: "Films",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Reservations_ReservationId",
                table: "Films",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Reservations_ReservationId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_ReservationId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "AgeRestriction",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Films",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "Cast",
                table: "Films",
                newName: "Watched");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Films",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "FilmReservation",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "int", nullable: false),
                    ReservationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmReservation", x => new { x.FilmsId, x.ReservationsId });
                    table.ForeignKey(
                        name: "FK_FilmReservation_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmReservation_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmReservation_ReservationsId",
                table: "FilmReservation",
                column: "ReservationsId");
        }
    }
}
