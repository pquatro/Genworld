using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorCenarioMVC.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class removedAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "TiposNpc");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TiposNpc");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TiposNpc");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TiposNpc");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "TiposMissao");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TiposMissao");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TiposMissao");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TiposMissao");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "TiposMateria");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TiposMateria");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TiposMateria");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TiposMateria");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "TiposConquista");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TiposConquista");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TiposConquista");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TiposConquista");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "StatusMissoes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "StatusMissoes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StatusMissoes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "StatusMissoes");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "SecoesRodape");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SecoesRodape");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SecoesRodape");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SecoesRodape");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "SecoesLateral");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SecoesLateral");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SecoesLateral");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SecoesLateral");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "SecoesCabecalho");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SecoesCabecalho");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SecoesCabecalho");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SecoesCabecalho");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Pcs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Pcs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Pcs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Pcs");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Missoes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Missoes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Missoes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Missoes");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Mapas");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Mapas");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Mapas");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Mapas");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Galerias");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Galerias");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Galerias");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Galerias");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Enredos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Enredos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Enredos");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Enredos");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Conquistas");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Conquistas");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Conquistas");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Conquistas");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Cenarios");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Cenarios");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Cenarios");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Cenarios");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "CenarioGeneros");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CenarioGeneros");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CenarioGeneros");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CenarioGeneros");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "CategoriasMateria");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CategoriasMateria");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CategoriasMateria");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CategoriasMateria");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Campanhas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "TiposNpc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TiposNpc",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TiposNpc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TiposNpc",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "TiposMissao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TiposMissao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TiposMissao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TiposMissao",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "TiposMateria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TiposMateria",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TiposMateria",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TiposMateria",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "TiposConquista",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TiposConquista",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TiposConquista",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TiposConquista",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "StatusMissoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "StatusMissoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "StatusMissoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "StatusMissoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Sessoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Sessoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Sessoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Sessoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "SecoesRodape",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SecoesRodape",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SecoesRodape",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SecoesRodape",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "SecoesLateral",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SecoesLateral",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SecoesLateral",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SecoesLateral",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "SecoesCabecalho",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SecoesCabecalho",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SecoesCabecalho",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SecoesCabecalho",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Pcs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Pcs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Pcs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Pcs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Npcs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Npcs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Npcs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Npcs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Missoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Missoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Missoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Missoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Materias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Materias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Materias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Materias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Mapas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Mapas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Mapas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Mapas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Imagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Imagens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Imagens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Imagens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Grupos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Grupos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Grupos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Grupos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Galerias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Galerias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Galerias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Galerias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Enredos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Enredos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Enredos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Enredos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Conquistas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Conquistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Conquistas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Conquistas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Cenarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Cenarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Cenarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Cenarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "CenarioGeneros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CenarioGeneros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CenarioGeneros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CenarioGeneros",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "CategoriasMateria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoriasMateria",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CategoriasMateria",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CategoriasMateria",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Campanhas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Campanhas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Campanhas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Campanhas",
                type: "datetime2",
                nullable: true);
        }
    }
}
