using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGHR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixHabitacionForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepcion_Cliente_ClienteIdCliente",
                table: "Recepcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Recepcion_Habitacion_HabitacionIdHabitacion",
                table: "Recepcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarifas_Habitacion_HabitacionIdHabitacion",
                table: "Tarifas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_RolUsuario_RolUsuarioIdRolUsuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RolUsuarioIdRolUsuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Tarifas_HabitacionIdHabitacion",
                table: "Tarifas");

            migrationBuilder.DropIndex(
                name: "IX_Recepcion_ClienteIdCliente",
                table: "Recepcion");

            migrationBuilder.DropIndex(
                name: "IX_Recepcion_HabitacionIdHabitacion",
                table: "Recepcion");

            migrationBuilder.DropColumn(
                name: "RolUsuarioIdRolUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "HabitacionIdHabitacion",
                table: "Tarifas");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Recepcion");

            migrationBuilder.DropColumn(
                name: "HabitacionIdHabitacion",
                table: "Recepcion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRolUsuario",
                table: "Usuario",
                column: "IdRolUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcion_IdHabitacion",
                table: "Recepcion",
                column: "IdHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepcion_Habitacion_IdHabitacion",
                table: "Recepcion",
                column: "IdHabitacion",
                principalTable: "Habitacion",
                principalColumn: "IdHabitacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_RolUsuario",
                table: "Usuario",
                column: "IdRolUsuario",
                principalTable: "RolUsuario",
                principalColumn: "IdRolUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepcion_Habitacion_IdHabitacion",
                table: "Recepcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_RolUsuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdRolUsuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Recepcion_IdHabitacion",
                table: "Recepcion");

            migrationBuilder.AddColumn<int>(
                name: "RolUsuarioIdRolUsuario",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HabitacionIdHabitacion",
                table: "Tarifas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Recepcion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HabitacionIdHabitacion",
                table: "Recepcion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolUsuarioIdRolUsuario",
                table: "Usuario",
                column: "RolUsuarioIdRolUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifas_HabitacionIdHabitacion",
                table: "Tarifas",
                column: "HabitacionIdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcion_ClienteIdCliente",
                table: "Recepcion",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcion_HabitacionIdHabitacion",
                table: "Recepcion",
                column: "HabitacionIdHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepcion_Cliente_ClienteIdCliente",
                table: "Recepcion",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepcion_Habitacion_HabitacionIdHabitacion",
                table: "Recepcion",
                column: "HabitacionIdHabitacion",
                principalTable: "Habitacion",
                principalColumn: "IdHabitacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarifas_Habitacion_HabitacionIdHabitacion",
                table: "Tarifas",
                column: "HabitacionIdHabitacion",
                principalTable: "Habitacion",
                principalColumn: "IdHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_RolUsuario_RolUsuarioIdRolUsuario",
                table: "Usuario",
                column: "RolUsuarioIdRolUsuario",
                principalTable: "RolUsuario",
                principalColumn: "IdRolUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
