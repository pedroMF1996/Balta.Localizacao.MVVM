using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Balta.Localizacao.MVVM.Data.Migrations
{
    /// <inheritdoc />
    public partial class IbgeStateNotUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IBGE_State",
                table: "IBGE");

            migrationBuilder.CreateIndex(
                name: "IX_IBGE_State",
                table: "IBGE",
                column: "State");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IBGE_State",
                table: "IBGE");

            migrationBuilder.CreateIndex(
                name: "IX_IBGE_State",
                table: "IBGE",
                column: "State",
                unique: true);
        }
    }
}
