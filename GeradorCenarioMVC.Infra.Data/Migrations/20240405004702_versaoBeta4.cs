using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorCenarioMVC.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class versaoBeta4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Campanhas_CampanhaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CampanhaId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CampanhaId",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "CampanhaUsuario",
                columns: table => new
                {
                    CampanhasId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaUsuario", x => new { x.CampanhasId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_CampanhaUsuario_Campanhas_CampanhasId",
                        column: x => x.CampanhasId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampanhaUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaUsuario_UsuariosId",
                table: "CampanhaUsuario",
                column: "UsuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampanhaUsuario");

            migrationBuilder.AddColumn<int>(
                name: "CampanhaId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CampanhaId",
                table: "Usuarios",
                column: "CampanhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Campanhas_CampanhaId",
                table: "Usuarios",
                column: "CampanhaId",
                principalTable: "Campanhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
