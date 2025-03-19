using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGHR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "EstadoHabitacion",
                columns: table => new
                {
                    IdEstadoHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoHabitacion", x => x.IdEstadoHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Piso",
                columns: table => new
                {
                    IdPiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piso", x => x.IdPiso);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    IdRolUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => x.IdRolUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRolUsuario = table.Column<int>(type: "int", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RolUsuarioIdRolUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_RolUsuario_RolUsuarioIdRolUsuario",
                        column: x => x.RolUsuarioIdRolUsuario,
                        principalTable: "RolUsuario",
                        principalColumn: "IdRolUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServicioIdServicio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_Categoria_Servicio_ServicioIdServicio",
                        column: x => x.ServicioIdServicio,
                        principalTable: "Servicio",
                        principalColumn: "IdServicio");
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IdEstadoHabitacion = table.Column<int>(type: "int", nullable: false),
                    IdPiso = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaIdCategoria = table.Column<int>(type: "int", nullable: true),
                    EstadoHabitacionIdEstadoHabitacion = table.Column<int>(type: "int", nullable: true),
                    PisoIdPiso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.IdHabitacion);
                    table.ForeignKey(
                        name: "FK_Habitacion_Categoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Habitacion_Categoria_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria");
                    table.ForeignKey(
                        name: "FK_Habitacion_EstadoHabitacion",
                        column: x => x.IdEstadoHabitacion,
                        principalTable: "EstadoHabitacion",
                        principalColumn: "IdEstadoHabitacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Habitacion_EstadoHabitacion_EstadoHabitacionIdEstadoHabitacion",
                        column: x => x.EstadoHabitacionIdEstadoHabitacion,
                        principalTable: "EstadoHabitacion",
                        principalColumn: "IdEstadoHabitacion");
                    table.ForeignKey(
                        name: "FK_Habitacion_Piso",
                        column: x => x.IdPiso,
                        principalTable: "Piso",
                        principalColumn: "IdPiso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Habitacion_Piso_PisoIdPiso",
                        column: x => x.PisoIdPiso,
                        principalTable: "Piso",
                        principalColumn: "IdPiso");
                });

            migrationBuilder.CreateTable(
                name: "Recepcion",
                columns: table => new
                {
                    IdRecepcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalidaConfirmacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrecioInicial = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Adelanto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PrecioRestante = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPagado = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CostoPenalidad = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HabitacionIdHabitacion = table.Column<int>(type: "int", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcion", x => x.IdRecepcion);
                    table.ForeignKey(
                        name: "FK_Recepcion_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recepcion_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Recepcion_Habitacion_HabitacionIdHabitacion",
                        column: x => x.HabitacionIdHabitacion,
                        principalTable: "Habitacion",
                        principalColumn: "IdHabitacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarifas",
                columns: table => new
                {
                    IdTarifa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioPorNoche = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HabitacionIdHabitacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifas", x => x.IdTarifa);
                    table.ForeignKey(
                        name: "FK_Tarifa_Habitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitacion",
                        principalColumn: "IdHabitacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarifas_Habitacion_HabitacionIdHabitacion",
                        column: x => x.HabitacionIdHabitacion,
                        principalTable: "Habitacion",
                        principalColumn: "IdHabitacion");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_ServicioIdServicio",
                table: "Categoria",
                column: "ServicioIdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_CategoriaIdCategoria",
                table: "Habitacion",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_EstadoHabitacionIdEstadoHabitacion",
                table: "Habitacion",
                column: "EstadoHabitacionIdEstadoHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_IdCategoria",
                table: "Habitacion",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_IdEstadoHabitacion",
                table: "Habitacion",
                column: "IdEstadoHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_IdPiso",
                table: "Habitacion",
                column: "IdPiso");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_PisoIdPiso",
                table: "Habitacion",
                column: "PisoIdPiso");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcion_ClienteIdCliente",
                table: "Recepcion",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcion_HabitacionIdHabitacion",
                table: "Recepcion",
                column: "HabitacionIdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcion_IdCliente",
                table: "Recepcion",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifas_HabitacionIdHabitacion",
                table: "Tarifas",
                column: "HabitacionIdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifas_IdHabitacion",
                table: "Tarifas",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolUsuarioIdRolUsuario",
                table: "Usuario",
                column: "RolUsuarioIdRolUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recepcion");

            migrationBuilder.DropTable(
                name: "Tarifas");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "EstadoHabitacion");

            migrationBuilder.DropTable(
                name: "Piso");

            migrationBuilder.DropTable(
                name: "Servicio");
        }
    }
}
