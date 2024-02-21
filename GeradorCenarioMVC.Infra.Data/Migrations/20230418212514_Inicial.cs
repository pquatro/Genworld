using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorCenarioMVC.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ConteudoSequence");

            migrationBuilder.CreateSequence(
                name: "SecaoWebSequence");

            migrationBuilder.CreateTable(
                name: "CategoriasMateria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenarioGeneros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galerias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecoesLateral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [SecaoWebSequence]"),
                    Css = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Topo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PainelTopo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PainelAbaixo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abaixo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposNpc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailVerificado = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    RecebeEmail = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
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

            migrationBuilder.CreateTable(
                name: "Cenarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Privado = table.Column<bool>(type: "bit", nullable: true),
                    Peso = table.Column<int>(type: "int", precision: 10, scale: 2, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCenario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaOficial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CenarioOficial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GaleriaId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "SecoesRodape",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [SecaoWebSequence]"),
                    Css = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NotaRodape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotaAutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaleriaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "SecoesCabecalho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [SecaoWebSequence]"),
                    Css = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubCabecalho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creditos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Conquistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoConquistaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolucao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotasSecretas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusMissaoId = table.Column<int>(type: "int", nullable: false),
                    TipoMissaoId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    NomePrimeiro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeUltimo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Caracteristicas = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Introducao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Raca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tendencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Olhos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cabelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pele = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Altura = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    Peso = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    NotasSecretas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visivel = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    TipoNpcId = table.Column<int>(type: "int", nullable: false),
                    GaleriaId = table.Column<int>(type: "int", nullable: true),
                    ImagemId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Pcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomePrimeiro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeUltimo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Caracteristicas = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Introducao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Raca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tendencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Olhos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cabelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pele = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Altura = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    Peso = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    NotasSecretas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frase = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JogadorId = table.Column<int>(type: "int", nullable: false),
                    GaleriaId = table.Column<int>(type: "int", nullable: true),
                    ImagemId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Campanhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Introducao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ImagemId = table.Column<int>(type: "int", nullable: true),
                    CenarioId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campanhas_Cenarios_CenarioId",
                        column: x => x.CenarioId,
                        principalTable: "Cenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campanhas_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
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
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ConteudoSequence]"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConteudoRestrito = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    PermitirComentario = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Peso = table.Column<int>(type: "int", precision: 10, scale: 2, nullable: true),
                    ExibirAutorTopo = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Icone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecaoCabecalhoId = table.Column<int>(type: "int", nullable: true),
                    SecaoRodapeId = table.Column<int>(type: "int", nullable: true),
                    SecaoLateralId = table.Column<int>(type: "int", nullable: true),
                    TipoMateriaId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Enredos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ConteudoSequence]"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConteudoRestrito = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    PermitirComentario = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Introducao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanoFundo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisaoGeral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GanchoPersonagens = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conclusao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aliados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampanhaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<int>(type: "int", precision: 10, scale: 2, nullable: true),
                    ExibirHomepageCenario = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Publico = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Legenda = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImagemId = table.Column<int>(type: "int", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "int", nullable: true),
                    OrganizacaoId = table.Column<int>(type: "int", nullable: true),
                    MateriaId = table.Column<int>(type: "int", nullable: true),
                    CenarioId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Sessoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracaoHoras = table.Column<int>(type: "int", nullable: true),
                    JogoOnline = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vtt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GmId = table.Column<int>(type: "int", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: true),
                    EnredoId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessoes_Enredos_EnredoId",
                        column: x => x.EnredoId,
                        principalTable: "Enredos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessoes_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessoes_Usuarios_GmId",
                        column: x => x.GmId,
                        principalTable: "Usuarios",
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
                name: "IX_Campanhas_CenarioId",
                table: "Campanhas",
                column: "CenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_ImagemId",
                table: "Campanhas",
                column: "ImagemId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_EnredoId",
                table: "Sessoes",
                column: "EnredoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_GmId",
                table: "Sessoes",
                column: "GmId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_GrupoId",
                table: "Sessoes",
                column: "GrupoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Npcs");

            migrationBuilder.DropTable(
                name: "Pcs");

            migrationBuilder.DropTable(
                name: "Mapas");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Missoes");

            migrationBuilder.DropTable(
                name: "Sessoes");

            migrationBuilder.DropTable(
                name: "TiposConquista");

            migrationBuilder.DropTable(
                name: "TiposNpc");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "StatusMissoes");

            migrationBuilder.DropTable(
                name: "TiposMissao");

            migrationBuilder.DropTable(
                name: "Enredos");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "SecoesCabecalho");

            migrationBuilder.DropTable(
                name: "SecoesLateral");

            migrationBuilder.DropTable(
                name: "SecoesRodape");

            migrationBuilder.DropTable(
                name: "TiposMateria");

            migrationBuilder.DropTable(
                name: "Campanhas");

            migrationBuilder.DropTable(
                name: "Cenarios");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "Galerias");

            migrationBuilder.DropSequence(
                name: "ConteudoSequence");

            migrationBuilder.DropSequence(
                name: "SecaoWebSequence");
        }
    }
}
