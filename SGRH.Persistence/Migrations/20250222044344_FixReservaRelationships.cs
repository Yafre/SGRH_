using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGRH.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixReservaRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Habitaciones_HabitacionIdHabitacion",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_HabitacionIdHabitacion",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "HabitacionIdHabitacion",
                table: "Reservas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HabitacionIdHabitacion",
                table: "Reservas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_HabitacionIdHabitacion",
                table: "Reservas",
                column: "HabitacionIdHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Habitaciones_HabitacionIdHabitacion",
                table: "Reservas",
                column: "HabitacionIdHabitacion",
                principalTable: "Habitaciones",
                principalColumn: "IdHabitacion");
        }
    }
}
