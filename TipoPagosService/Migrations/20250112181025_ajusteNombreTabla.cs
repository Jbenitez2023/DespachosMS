using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TipoPagosService.Migrations
{
    /// <inheritdoc />
    public partial class ajusteNombreTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CmpoTypePay",
                table: "CmpoTypePay");

            migrationBuilder.RenameTable(
                name: "CmpoTypePay",
                newName: "CmpTypePay");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CmpTypePay",
                table: "CmpTypePay",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CmpTypePay",
                table: "CmpTypePay");

            migrationBuilder.RenameTable(
                name: "CmpTypePay",
                newName: "CmpoTypePay");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CmpoTypePay",
                table: "CmpoTypePay",
                column: "Id");
        }
    }
}
