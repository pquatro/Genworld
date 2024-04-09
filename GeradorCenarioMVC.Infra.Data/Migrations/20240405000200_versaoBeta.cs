using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorCenarioMVC.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class versaoBeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanhas_Cenarios_CenarioId",
                table: "Campanhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Enredos_EnredoId",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Grupos_GrupoId",
                table: "Sessoes");

            migrationBuilder.DropTable(
                name: "CampanhaGrupo");

            migrationBuilder.DropTable(
                name: "CampanhaNpc");

            migrationBuilder.DropTable(
                name: "CampanhaPc");

            migrationBuilder.DropTable(
                name: "CategoriaMateriaMateria");

            migrationBuilder.DropTable(
                name: "CenarioCenarioGenero");

            migrationBuilder.DropTable(
                name: "CenarioMateria");

            migrationBuilder.DropTable(
                name: "CenarioTag");

            migrationBuilder.DropTable(
                name: "ConquistaNpc");

            migrationBuilder.DropTable(
                name: "ConquistaPc");

            migrationBuilder.DropTable(
                name: "EnredoPc");

            migrationBuilder.DropTable(
                name: "GaleriaImagem");

            migrationBuilder.DropTable(
                name: "GrupoNpc");

            migrationBuilder.DropTable(
                name: "GrupoPc");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "MapaTag");

            migrationBuilder.DropTable(
                name: "MissaoSessao");

            migrationBuilder.DropTable(
                name: "CategoriasMateria");

            migrationBuilder.DropTable(
                name: "CenarioGeneros");

            migrationBuilder.DropTable(
                name: "Conquistas");

            migrationBuilder.DropTable(
                name: "Enredos");

            migrationBuilder.DropTable(
                name: "Npcs");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Pcs");

            migrationBuilder.DropTable(
                name: "Mapas");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Missoes");

            migrationBuilder.DropTable(
                name: "TiposConquista");

            migrationBuilder.DropTable(
                name: "TiposNpc");

            migrationBuilder.DropTable(
                name: "Cenarios");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "StatusMissoes");

            migrationBuilder.DropTable(
                name: "TiposMissao");

            migrationBuilder.DropTable(
                name: "SecoesCabecalho");

            migrationBuilder.DropTable(
                name: "SecoesLateral");

            migrationBuilder.DropTable(
                name: "SecoesRodape");

            migrationBuilder.DropTable(
                name: "TiposMateria");

            migrationBuilder.DropTable(
                name: "Galerias");

            migrationBuilder.DropIndex(
                name: "IX_Sessoes_GrupoId",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Campanhas_CenarioId",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "DuracaoHoras",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "JogoOnline",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "Introducao",
                table: "Campanhas");

            migrationBuilder.DropSequence(
                name: "ConteudoSequence");

            migrationBuilder.DropSequence(
                name: "SecaoWebSequence");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Usuarios",
                newName: "FotoBytes");

            migrationBuilder.RenameColumn(
                name: "NomeUltimo",
                table: "Usuarios",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "NomePrimeiro",
                table: "Usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "GrupoId",
                table: "Sessoes",
                newName: "Duracao");

            migrationBuilder.RenameColumn(
                name: "EnredoId",
                table: "Sessoes",
                newName: "CampanhaId");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Sessoes",
                newName: "DataSessao");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_EnredoId",
                table: "Sessoes",
                newName: "IX_Sessoes_CampanhaId");

            migrationBuilder.RenameColumn(
                name: "CenarioId",
                table: "Campanhas",
                newName: "StatusCampanhaId");

            migrationBuilder.AlterColumn<bool>(
                name: "EmailVerificado",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CampanhaId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FotoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessaoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Online",
                table: "Sessoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Recompensa",
                table: "Sessoes",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Campanhas",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Cenario",
                table: "Campanhas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CriadoPorId",
                table: "Campanhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Campanhas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MestreId",
                table: "Campanhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Campanhas",
                type: "int",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Privado",
                table: "Campanhas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Sistema",
                table: "Campanhas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCampanha",
                table: "Campanhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampanhaGenero",
                columns: table => new
                {
                    CampanhasId = table.Column<int>(type: "int", nullable: false),
                    GenerosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaGenero", x => new { x.CampanhasId, x.GenerosId });
                    table.ForeignKey(
                        name: "FK_CampanhaGenero_Campanhas_CampanhasId",
                        column: x => x.CampanhasId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampanhaGenero_Generos_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CampanhaId",
                table: "Usuarios",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FotoId",
                table: "Usuarios",
                column: "FotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SessaoId",
                table: "Usuarios",
                column: "SessaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_CriadoPorId",
                table: "Campanhas",
                column: "CriadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_MestreId",
                table: "Campanhas",
                column: "MestreId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaGenero_GenerosId",
                table: "CampanhaGenero",
                column: "GenerosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanhas_Usuarios_CriadoPorId",
                table: "Campanhas",
                column: "CriadoPorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campanhas_Usuarios_MestreId",
                table: "Campanhas",
                column: "MestreId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Campanhas_CampanhaId",
                table: "Sessoes",
                column: "CampanhaId",
                principalTable: "Campanhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Campanhas_CampanhaId",
                table: "Usuarios",
                column: "CampanhaId",
                principalTable: "Campanhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Imagens_FotoId",
                table: "Usuarios",
                column: "FotoId",
                principalTable: "Imagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Sessoes_SessaoId",
                table: "Usuarios",
                column: "SessaoId",
                principalTable: "Sessoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanhas_Usuarios_CriadoPorId",
                table: "Campanhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Campanhas_Usuarios_MestreId",
                table: "Campanhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Campanhas_CampanhaId",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Campanhas_CampanhaId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Imagens_FotoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Sessoes_SessaoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "CampanhaGenero");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CampanhaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_FotoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_SessaoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Campanhas_CriadoPorId",
                table: "Campanhas");

            migrationBuilder.DropIndex(
                name: "IX_Campanhas_MestreId",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "CampanhaId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FotoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SessaoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Online",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "Recompensa",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "Cenario",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "CriadoPorId",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "MestreId",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "Privado",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "Sistema",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "StatusCampanha",
                table: "Campanhas");

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Usuarios",
                newName: "NomeUltimo");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuarios",
                newName: "NomePrimeiro");

            migrationBuilder.RenameColumn(
                name: "FotoBytes",
                table: "Usuarios",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "Duracao",
                table: "Sessoes",
                newName: "GrupoId");

            migrationBuilder.RenameColumn(
                name: "DataSessao",
                table: "Sessoes",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "CampanhaId",
                table: "Sessoes",
                newName: "EnredoId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_CampanhaId",
                table: "Sessoes",
                newName: "IX_Sessoes_EnredoId");

            migrationBuilder.RenameColumn(
                name: "StatusCampanhaId",
                table: "Campanhas",
                newName: "CenarioId");

            migrationBuilder.CreateSequence(
                name: "ConteudoSequence");

            migrationBuilder.CreateSequence(
                name: "SecaoWebSequence");

            migrationBuilder.AlterColumn<bool>(
                name: "EmailVerificado",
                table: "Usuarios",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Usuarios",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DuracaoHoras",
                table: "Sessoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "JogoOnline",
                table: "Sessoes",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Campanhas",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Introducao",
                table: "Campanhas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriasMateria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasMateria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriasMateria_CategoriasMateria_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CategoriasMateria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CenarioGeneros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenarioGeneros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enredos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ConteudoSequence]"),
                    ConteudoRestrito = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermitirComentario = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CampanhaId = table.Column<int>(type: "int", nullable: false),
                    Aliados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conclusao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GanchoPersonagens = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Introducao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanoFundo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisaoGeral = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enredos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enredos_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Galerias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galerias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecoesCabecalho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [SecaoWebSequence]"),
                    Css = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Creditos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemId = table.Column<int>(type: "int", nullable: true),
                    SubCabecalho = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecoesCabecalho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecoesCabecalho_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecoesLateral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [SecaoWebSequence]"),
                    Css = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Abaixo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PainelAbaixo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PainelTopo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecoesLateral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusMissoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMissoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposConquista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposConquista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposMateria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMateria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposMissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposNpc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposNpc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cenarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GaleriaId = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CenarioOficial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataCenario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Peso = table.Column<int>(type: "int", precision: 10, scale: 2, nullable: true),
                    Privado = table.Column<bool>(type: "bit", nullable: true),
                    SistemaOficial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cenarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cenarios_Galerias_GaleriaId",
                        column: x => x.GaleriaId,
                        principalTable: "Galerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GaleriaImagem",
                columns: table => new
                {
                    GaleriasId = table.Column<int>(type: "int", nullable: false),
                    ImagensId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriaImagem", x => new { x.GaleriasId, x.ImagensId });
                    table.ForeignKey(
                        name: "FK_GaleriaImagem_Galerias_GaleriasId",
                        column: x => x.GaleriasId,
                        principalTable: "Galerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GaleriaImagem_Imagens_ImagensId",
                        column: x => x.ImagensId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    Apelido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cabelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Caracteristicas = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Introducao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Nascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomePrimeiro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeUltimo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NotasSecretas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Olhos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pele = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Peso = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    Raca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tendencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GaleriaId = table.Column<int>(type: "int", nullable: true),
                    ImagemId = table.Column<int>(type: "int", nullable: true),
                    JogadorId = table.Column<int>(type: "int", nullable: false),
                    Frase = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pcs_Galerias_GaleriaId",
                        column: x => x.GaleriaId,
                        principalTable: "Galerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pcs_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pcs_Usuarios_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecoesRodape",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [SecaoWebSequence]"),
                    Css = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GaleriaId = table.Column<int>(type: "int", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotaAutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotaRodape = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecoesRodape", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecoesRodape_Galerias_GaleriaId",
                        column: x => x.GaleriaId,
                        principalTable: "Galerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampanhaGrupo",
                columns: table => new
                {
                    CampanhasId = table.Column<int>(type: "int", nullable: false),
                    GruposId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaGrupo", x => new { x.CampanhasId, x.GruposId });
                    table.ForeignKey(
                        name: "FK_CampanhaGrupo_Campanhas_CampanhasId",
                        column: x => x.CampanhasId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampanhaGrupo_Grupos_GruposId",
                        column: x => x.GruposId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conquistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoConquistaId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conquistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conquistas_TiposConquista_TipoConquistaId",
                        column: x => x.TipoConquistaId,
                        principalTable: "TiposConquista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Missoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusMissaoId = table.Column<int>(type: "int", nullable: false),
                    TipoMissaoId = table.Column<int>(type: "int", nullable: false),
                    NotasSecretas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolucao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missoes_StatusMissoes_StatusMissaoId",
                        column: x => x.StatusMissaoId,
                        principalTable: "StatusMissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Missoes_TiposMissao_TipoMissaoId",
                        column: x => x.TipoMissaoId,
                        principalTable: "TiposMissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Npcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    Apelido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cabelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Caracteristicas = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Introducao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Nascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomePrimeiro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeUltimo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NotasSecretas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Olhos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pele = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Peso = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    Raca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tendencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GaleriaId = table.Column<int>(type: "int", nullable: true),
                    ImagemId = table.Column<int>(type: "int", nullable: true),
                    TipoNpcId = table.Column<int>(type: "int", nullable: false),
                    Visivel = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Npcs_Galerias_GaleriaId",
                        column: x => x.GaleriaId,
                        principalTable: "Galerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Npcs_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Npcs_TiposNpc_Id",
                        column: x => x.Id,
                        principalTable: "TiposNpc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CenarioCenarioGenero",
                columns: table => new
                {
                    CenarioGenerosId = table.Column<int>(type: "int", nullable: false),
                    CenariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenarioCenarioGenero", x => new { x.CenarioGenerosId, x.CenariosId });
                    table.ForeignKey(
                        name: "FK_CenarioCenarioGenero_CenarioGeneros_CenarioGenerosId",
                        column: x => x.CenarioGenerosId,
                        principalTable: "CenarioGeneros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CenarioCenarioGenero_Cenarios_CenariosId",
                        column: x => x.CenariosId,
                        principalTable: "Cenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CenarioTag",
                columns: table => new
                {
                    CenariosId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenarioTag", x => new { x.CenariosId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_CenarioTag_Cenarios_CenariosId",
                        column: x => x.CenariosId,
                        principalTable: "Cenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CenarioTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampanhaPc",
                columns: table => new
                {
                    CampanhasId = table.Column<int>(type: "int", nullable: false),
                    PcsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaPc", x => new { x.CampanhasId, x.PcsId });
                    table.ForeignKey(
                        name: "FK_CampanhaPc_Campanhas_CampanhasId",
                        column: x => x.CampanhasId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampanhaPc_Pcs_PcsId",
                        column: x => x.PcsId,
                        principalTable: "Pcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnredoPc",
                columns: table => new
                {
                    EnredosId = table.Column<int>(type: "int", nullable: false),
                    PcsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnredoPc", x => new { x.EnredosId, x.PcsId });
                    table.ForeignKey(
                        name: "FK_EnredoPc_Enredos_EnredosId",
                        column: x => x.EnredosId,
                        principalTable: "Enredos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnredoPc_Pcs_PcsId",
                        column: x => x.PcsId,
                        principalTable: "Pcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrupoPc",
                columns: table => new
                {
                    GruposId = table.Column<int>(type: "int", nullable: false),
                    PCsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoPc", x => new { x.GruposId, x.PCsId });
                    table.ForeignKey(
                        name: "FK_GrupoPc_Grupos_GruposId",
                        column: x => x.GruposId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrupoPc_Pcs_PCsId",
                        column: x => x.PCsId,
                        principalTable: "Pcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ConteudoSequence]"),
                    ConteudoRestrito = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermitirComentario = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    SecaoCabecalhoId = table.Column<int>(type: "int", nullable: true),
                    SecaoLateralId = table.Column<int>(type: "int", nullable: true),
                    SecaoRodapeId = table.Column<int>(type: "int", nullable: true),
                    TipoMateriaId = table.Column<int>(type: "int", nullable: false),
                    ExibirAutorTopo = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Icone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<int>(type: "int", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_Materias_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materias_SecoesCabecalho_SecaoCabecalhoId",
                        column: x => x.SecaoCabecalhoId,
                        principalTable: "SecoesCabecalho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materias_SecoesLateral_SecaoLateralId",
                        column: x => x.SecaoLateralId,
                        principalTable: "SecoesLateral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materias_SecoesRodape_SecaoRodapeId",
                        column: x => x.SecaoRodapeId,
                        principalTable: "SecoesRodape",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materias_TiposMateria_TipoMateriaId",
                        column: x => x.TipoMateriaId,
                        principalTable: "TiposMateria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConquistaPc",
                columns: table => new
                {
                    ConquistasId = table.Column<int>(type: "int", nullable: false),
                    PcsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquistaPc", x => new { x.ConquistasId, x.PcsId });
                    table.ForeignKey(
                        name: "FK_ConquistaPc_Conquistas_ConquistasId",
                        column: x => x.ConquistasId,
                        principalTable: "Conquistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConquistaPc_Pcs_PcsId",
                        column: x => x.PcsId,
                        principalTable: "Pcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MissaoSessao",
                columns: table => new
                {
                    MissoesId = table.Column<int>(type: "int", nullable: false),
                    SessoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissaoSessao", x => new { x.MissoesId, x.SessoesId });
                    table.ForeignKey(
                        name: "FK_MissaoSessao_Missoes_MissoesId",
                        column: x => x.MissoesId,
                        principalTable: "Missoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MissaoSessao_Sessoes_SessoesId",
                        column: x => x.SessoesId,
                        principalTable: "Sessoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampanhaNpc",
                columns: table => new
                {
                    CampanhasId = table.Column<int>(type: "int", nullable: false),
                    NpcsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaNpc", x => new { x.CampanhasId, x.NpcsId });
                    table.ForeignKey(
                        name: "FK_CampanhaNpc_Campanhas_CampanhasId",
                        column: x => x.CampanhasId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampanhaNpc_Npcs_NpcsId",
                        column: x => x.NpcsId,
                        principalTable: "Npcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConquistaNpc",
                columns: table => new
                {
                    ConquistasId = table.Column<int>(type: "int", nullable: false),
                    NpcsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquistaNpc", x => new { x.ConquistasId, x.NpcsId });
                    table.ForeignKey(
                        name: "FK_ConquistaNpc_Conquistas_ConquistasId",
                        column: x => x.ConquistasId,
                        principalTable: "Conquistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConquistaNpc_Npcs_NpcsId",
                        column: x => x.NpcsId,
                        principalTable: "Npcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrupoNpc",
                columns: table => new
                {
                    GruposId = table.Column<int>(type: "int", nullable: false),
                    NPCsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoNpc", x => new { x.GruposId, x.NPCsId });
                    table.ForeignKey(
                        name: "FK_GrupoNpc_Grupos_GruposId",
                        column: x => x.GruposId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrupoNpc_Npcs_NPCsId",
                        column: x => x.NPCsId,
                        principalTable: "Npcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaMateriaMateria",
                columns: table => new
                {
                    CategoriasMateriaId = table.Column<int>(type: "int", nullable: false),
                    MateriasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMateriaMateria", x => new { x.CategoriasMateriaId, x.MateriasId });
                    table.ForeignKey(
                        name: "FK_CategoriaMateriaMateria_CategoriasMateria_CategoriasMateriaId",
                        column: x => x.CategoriasMateriaId,
                        principalTable: "CategoriasMateria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoriaMateriaMateria_Materias_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CenarioMateria",
                columns: table => new
                {
                    CenariosId = table.Column<int>(type: "int", nullable: false),
                    MateriasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenarioMateria", x => new { x.CenariosId, x.MateriasId });
                    table.ForeignKey(
                        name: "FK_CenarioMateria_Cenarios_CenariosId",
                        column: x => x.CenariosId,
                        principalTable: "Cenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CenarioMateria_Materias_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mapas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenarioId = table.Column<int>(type: "int", nullable: false),
                    ImagemId = table.Column<int>(type: "int", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "int", nullable: true),
                    MateriaId = table.Column<int>(type: "int", nullable: true),
                    OrganizacaoId = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExibirHomepageCenario = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Legenda = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Peso = table.Column<int>(type: "int", precision: 10, scale: 2, nullable: true),
                    Publico = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mapas_Cenarios_CenarioId",
                        column: x => x.CenarioId,
                        principalTable: "Cenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mapas_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mapas_Materias_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mapas_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mapas_Materias_OrganizacaoId",
                        column: x => x.OrganizacaoId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MapaTag",
                columns: table => new
                {
                    MapasId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapaTag", x => new { x.MapasId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_MapaTag_Mapas_MapasId",
                        column: x => x.MapasId,
                        principalTable: "Mapas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MapaTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_GrupoId",
                table: "Sessoes",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_CenarioId",
                table: "Campanhas",
                column: "CenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaGrupo_GruposId",
                table: "CampanhaGrupo",
                column: "GruposId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaNpc_NpcsId",
                table: "CampanhaNpc",
                column: "NpcsId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaPc_PcsId",
                table: "CampanhaPc",
                column: "PcsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaMateriaMateria_MateriasId",
                table: "CategoriaMateriaMateria",
                column: "MateriasId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasMateria_ParentId",
                table: "CategoriasMateria",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CenarioCenarioGenero_CenariosId",
                table: "CenarioCenarioGenero",
                column: "CenariosId");

            migrationBuilder.CreateIndex(
                name: "IX_CenarioMateria_MateriasId",
                table: "CenarioMateria",
                column: "MateriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Cenarios_GaleriaId",
                table: "Cenarios",
                column: "GaleriaId");

            migrationBuilder.CreateIndex(
                name: "IX_CenarioTag_TagsId",
                table: "CenarioTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquistaNpc_NpcsId",
                table: "ConquistaNpc",
                column: "NpcsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquistaPc_PcsId",
                table: "ConquistaPc",
                column: "PcsId");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistas_TipoConquistaId",
                table: "Conquistas",
                column: "TipoConquistaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnredoPc_PcsId",
                table: "EnredoPc",
                column: "PcsId");

            migrationBuilder.CreateIndex(
                name: "IX_Enredos_CampanhaId",
                table: "Enredos",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_GaleriaImagem_ImagensId",
                table: "GaleriaImagem",
                column: "ImagensId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoNpc_NPCsId",
                table: "GrupoNpc",
                column: "NPCsId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPc_PCsId",
                table: "GrupoPc",
                column: "PCsId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapas_CenarioId",
                table: "Mapas",
                column: "CenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapas_ImagemId",
                table: "Mapas",
                column: "ImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapas_LocalizacaoId",
                table: "Mapas",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapas_MateriaId",
                table: "Mapas",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapas_OrganizacaoId",
                table: "Mapas",
                column: "OrganizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_MapaTag_TagsId",
                table: "MapaTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_ParentId",
                table: "Materias",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_SecaoCabecalhoId",
                table: "Materias",
                column: "SecaoCabecalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_SecaoLateralId",
                table: "Materias",
                column: "SecaoLateralId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_SecaoRodapeId",
                table: "Materias",
                column: "SecaoRodapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_TipoMateriaId",
                table: "Materias",
                column: "TipoMateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_MissaoSessao_SessoesId",
                table: "MissaoSessao",
                column: "SessoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Missoes_StatusMissaoId",
                table: "Missoes",
                column: "StatusMissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Missoes_TipoMissaoId",
                table: "Missoes",
                column: "TipoMissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Npcs_GaleriaId",
                table: "Npcs",
                column: "GaleriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Npcs_ImagemId",
                table: "Npcs",
                column: "ImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_GaleriaId",
                table: "Pcs",
                column: "GaleriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_ImagemId",
                table: "Pcs",
                column: "ImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_JogadorId",
                table: "Pcs",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_SecoesCabecalho_ImagemId",
                table: "SecoesCabecalho",
                column: "ImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_SecoesRodape_GaleriaId",
                table: "SecoesRodape",
                column: "GaleriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanhas_Cenarios_CenarioId",
                table: "Campanhas",
                column: "CenarioId",
                principalTable: "Cenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Enredos_EnredoId",
                table: "Sessoes",
                column: "EnredoId",
                principalTable: "Enredos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Grupos_GrupoId",
                table: "Sessoes",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
