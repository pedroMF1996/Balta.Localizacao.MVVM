using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Balta.Localizacao.MVVM.Data.Migrations.LocalizacaoDbContexMigrations
{
    /// <inheritdoc />
    public partial class InitialLocalizacaoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IBGE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(7)", maxLength: 7, nullable: false),
                    City = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    State = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IBGE", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IBGE_City",
                table: "IBGE",
                column: "City",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IBGE_Id",
                table: "IBGE",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IBGE_State",
                table: "IBGE",
                column: "State",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IBGE");
        }
    }
}
