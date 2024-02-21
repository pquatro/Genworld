using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorCenarioMVC.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class usuarioAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pcs");

            migrationBuilder.AddColumn<int>(
                name: "GmId",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JogadorId",
                table: "Pcs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 450, nullable: false),
                    NomePrimeiro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeUltimo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailVerificado = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    RecebeEmail = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_GmId",
                table: "Sessoes",
                column: "GmId");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_JogadorId",
                table: "Pcs",
                column: "JogadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pcs_Usuarios_JogadorId",
                table: "Pcs",
                column: "JogadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Usuarios_GmId",
                table: "Sessoes",
                column: "GmId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pcs_Usuarios_JogadorId",
                table: "Pcs");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Usuarios_GmId",
                table: "Sessoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Sessoes_GmId",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Pcs_JogadorId",
                table: "Pcs");

            migrationBuilder.DropColumn(
                name: "GmId",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "JogadorId",
                table: "Pcs");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Sessoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Pcs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
