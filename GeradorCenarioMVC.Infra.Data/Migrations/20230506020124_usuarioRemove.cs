using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorCenarioMVC.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class usuarioRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RecebeEmail",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimoAcesso",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pcs");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RecebeEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UltimoAcesso",
                table: "AspNetUsers");

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
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailVerificado = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomePrimeiro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeUltimo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RecebeEmail = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
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
    }
}
