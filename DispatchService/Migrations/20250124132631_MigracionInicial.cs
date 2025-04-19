using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispatchService.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CMPDispatch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDespacho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMensual = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDespacho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOperaciones = table.Column<int>(type: "int", nullable: false),
                    IdDespachoFlujo = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdEstadoDespacho = table.Column<int>(type: "int", nullable: false),
                    VencimientoDus = table.Column<DateTime>(type: "datetime2", nullable: true),
                    referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacturaHYF = table.Column<bool>(type: "bit", nullable: true),
                    IdTipoServicios = table.Column<int>(type: "int", nullable: true),
                    GastosDespacho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacturaOrtiz = table.Column<bool>(type: "bit", nullable: true),
                    IdEstadoFacturacion = table.Column<int>(type: "int", nullable: true),
                    IdEstadoPago = table.Column<int>(type: "int", nullable: true),
                    NroFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoPago = table.Column<int>(type: "int", nullable: true),
                    FacturaExportacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mandato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnexoDus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PagoTgr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificadoOrigen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CDASALUD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnexoDin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConocimientoEmbarque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListaEmpaque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MICDTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Factura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnexoFacturaHYF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaFacturacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMPDispatch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMPDispatchAnnexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDespacho = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anexo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMPDispatchAnnexes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CMPDispatchAnnexes_CMPDispatch_IdDespacho",
                        column: x => x.IdDespacho,
                        principalTable: "CMPDispatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CMPDispatchAnnexes_IdDespacho",
                table: "CMPDispatchAnnexes",
                column: "IdDespacho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMPDispatchAnnexes");

            migrationBuilder.DropTable(
                name: "CMPDispatch");
        }
    }
}
