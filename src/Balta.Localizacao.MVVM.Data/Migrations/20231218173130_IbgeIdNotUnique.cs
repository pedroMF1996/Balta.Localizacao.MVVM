using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Balta.Localizacao.MVVM.Data.Migrations
{
    /// <inheritdoc />
    public partial class IbgeIdNotUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IBGE_Id",
                table: "IBGE");

            migrationBuilder.CreateIndex(
                name: "IX_IBGE_Id",
                table: "IBGE",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IBGE_Id",
                table: "IBGE");

            migrationBuilder.CreateIndex(
                name: "IX_IBGE_Id",
                table: "IBGE",
                column: "Id",
                unique: true);
        }
    }
}
