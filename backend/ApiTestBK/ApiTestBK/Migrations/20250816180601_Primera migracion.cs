using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiTestBK.Migrations
{
    /// <inheritdoc />
    public partial class Primeramigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contribuyentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RncCedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuyentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComprobantesFiscales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RncCedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NCF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Itbis18 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContribuyenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobantesFiscales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprobantesFiscales_Contribuyentes_ContribuyenteId",
                        column: x => x.ContribuyenteId,
                        principalTable: "Contribuyentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contribuyentes",
                columns: new[] { "Id", "Estatus", "Nombre", "RncCedula", "Tipo" },
                values: new object[,]
                {
                    { 1, "activo", "JUAN PEREZ", "00112345678", "PERSONA FISICA" },
                    { 2, "activo", "MARIA LOPEZ", "00187654321", "PERSONA FISICA" },
                    { 3, "inactivo", "EMPRESAS DOMINICANAS SRL", "13145678901", "PERSONA JURIDICA" },
                    { 4, "suspendido", "PEDRO GARCIA", "40211222333", "PERSONA FISICA" },
                    { 5, "activo", "SOLUCIONES TECNICAS EIRL", "40199887766", "PERSONA JURIDICA" }
                });

            migrationBuilder.InsertData(
                table: "ComprobantesFiscales",
                columns: new[] { "Id", "ContribuyenteId", "Itbis18", "Monto", "NCF", "RncCedula" },
                values: new object[,]
                {
                    { 1, 1, 36.00m, 200.00m, "E310000000001", "00112345678" },
                    { 2, 1, 270.00m, 1500.00m, "E310000000002", "00112345678" },
                    { 3, 2, 90.00m, 500.00m, "E310000000003", "00187654321" },
                    { 4, 3, 1800.00m, 10000.00m, "B010000000001", "13145678901" },
                    { 5, 3, 1350.00m, 7500.00m, "B010000000002", "13145678901" },
                    { 6, 3, 450.00m, 2500.00m, "B010000000003", "13145678901" },
                    { 7, 5, 216.00m, 1200.00m, "E310000000004", "40199887766" },
                    { 8, 5, 54.00m, 300.00m, "E310000000005", "40199887766" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesFiscales_ContribuyenteId",
                table: "ComprobantesFiscales",
                column: "ContribuyenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprobantesFiscales");

            migrationBuilder.DropTable(
                name: "Contribuyentes");
        }
    }
}
