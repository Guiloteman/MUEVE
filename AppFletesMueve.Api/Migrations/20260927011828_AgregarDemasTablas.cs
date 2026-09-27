using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppFletesMueve.Api.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDemasTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductores",
                columns: table => new
                {
                    ConductorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Licencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.ConductorId);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    SolicitudCargaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudFleteId = table.Column<int>(type: "int", nullable: false),
                    TipoCargaId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PesoKg = table.Column<double>(type: "float", nullable: false),
                    VolumenM3 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.SolicitudCargaId);
                });

            migrationBuilder.CreateTable(
                name: "TiposCarga",
                columns: table => new
                {
                    TipoCargaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoEstimadoKg = table.Column<double>(type: "float", nullable: false),
                    VolumenEstimadoM3 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCarga", x => x.TipoCargaId);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoModelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoModelos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConductorId = table.Column<int>(type: "int", nullable: false),
                    Patente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    TipoVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadKg = table.Column<double>(type: "float", nullable: false),
                    VolumenM3 = table.Column<double>(type: "float", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.VehiculoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conductores");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "TiposCarga");

            migrationBuilder.DropTable(
                name: "VehiculoModelos");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
