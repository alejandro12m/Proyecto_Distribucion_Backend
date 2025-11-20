using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Distribucion.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaSalida",
                table: "Envio",
                newName: "FechaEnvio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaEnvio",
                table: "Envio",
                newName: "FechaSalida");
        }
    }
}
