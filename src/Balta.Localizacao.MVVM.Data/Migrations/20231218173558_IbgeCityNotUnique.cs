using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Balta.Localizacao.MVVM.Data.Migrations
{
    /// <inheritdoc />
    public partial class IbgeCityNotUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IBGE_City",
                table: "IBGE");

            migrationBuilder.CreateIndex(
                name: "IX_IBGE_City",
                table: "IBGE",
                column: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IBGE_City",
                table: "IBGE");

            migrationBuilder.CreateIndex(
                name: "IX_IBGE_City",
                table: "IBGE",
                column: "City",
                unique: true);
        }
    }
}
