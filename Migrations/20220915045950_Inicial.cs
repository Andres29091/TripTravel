using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripTravel.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoHotel = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumeroPlazas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoSucursal = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTurista = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroVuelo = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Origen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Destino = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlazaTotal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlazaTurista = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContratoSucursal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTurista = table.Column<int>(type: "int", nullable: false),
                    CodigoSucursal = table.Column<int>(type: "int", nullable: false),
                    TuristaId = table.Column<int>(type: "int", nullable: true),
                    SucursalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoSucursal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratoSucursal_Sucursal_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContratoSucursal_Turista_TuristaId",
                        column: x => x.TuristaId,
                        principalTable: "Turista",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservaHotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTurista = table.Column<int>(type: "int", nullable: false),
                    CodigoHotel = table.Column<int>(type: "int", nullable: false),
                    Regimen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPartida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    TuristaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaHotel_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReservaHotel_Turista_TuristaId",
                        column: x => x.TuristaId,
                        principalTable: "Turista",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservaVuelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTurista = table.Column<int>(type: "int", nullable: false),
                    NumeroVuelo = table.Column<int>(type: "int", nullable: false),
                    Clase = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VueloId = table.Column<int>(type: "int", nullable: true),
                    TuristaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaVuelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaVuelo_Turista_TuristaId",
                        column: x => x.TuristaId,
                        principalTable: "Turista",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReservaVuelo_Vuelo_VueloId",
                        column: x => x.VueloId,
                        principalTable: "Vuelo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratoSucursal_SucursalId",
                table: "ContratoSucursal",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoSucursal_TuristaId",
                table: "ContratoSucursal",
                column: "TuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHotel_HotelId",
                table: "ReservaHotel",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHotel_TuristaId",
                table: "ReservaHotel",
                column: "TuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVuelo_TuristaId",
                table: "ReservaVuelo",
                column: "TuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVuelo_VueloId",
                table: "ReservaVuelo",
                column: "VueloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratoSucursal");

            migrationBuilder.DropTable(
                name: "ReservaHotel");

            migrationBuilder.DropTable(
                name: "ReservaVuelo");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Turista");

            migrationBuilder.DropTable(
                name: "Vuelo");
        }
    }
}
