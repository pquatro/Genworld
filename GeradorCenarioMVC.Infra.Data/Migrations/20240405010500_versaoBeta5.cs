using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorCenarioMVC.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class versaoBeta5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Sessoes_SessaoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_SessaoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SessaoId",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "SessaoUsuario",
                columns: table => new
                {
                    SessoesId = table.Column<int>(type: "int", nullable: false),
                    UsuariosPresentesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessaoUsuario", x => new { x.SessoesId, x.UsuariosPresentesId });
                    table.ForeignKey(
                        name: "FK_SessaoUsuario_Sessoes_SessoesId",
                        column: x => x.SessoesId,
                        principalTable: "Sessoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessaoUsuario_Usuarios_UsuariosPresentesId",
                        column: x => x.UsuariosPresentesId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessaoUsuario_UsuariosPresentesId",
                table: "SessaoUsuario",
                column: "UsuariosPresentesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessaoUsuario");

            migrationBuilder.AddColumn<int>(
                name: "SessaoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SessaoId",
                table: "Usuarios",
                column: "SessaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Sessoes_SessaoId",
                table: "Usuarios",
                column: "SessaoId",
                principalTable: "Sessoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
