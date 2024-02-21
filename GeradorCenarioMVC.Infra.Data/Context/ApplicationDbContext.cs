using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace GeradorCenarioMVC.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opttions) : base(opttions) { }

        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<CategoriaMateria> CategoriasMateria { get; set; }
        public DbSet<Cenario> Cenarios { get; set; }
        public DbSet<CenarioGenero> CenarioGeneros { get; set; }
        public DbSet<Conquista> Conquistas { get; set; }
        public DbSet<Enredo> Enredos { get; set; }
        public DbSet<Galeria> Galerias { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Mapa> Mapas { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Missao> Missoes { get; set; }
        public DbSet<Npc> Npcs { get; set; }
        public DbSet<Pc> Pcs { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<SecaoCabecalho> SecoesCabecalho { get; set; }
        public DbSet<SecaoLateral> SecoesLateral { get; set; }
        public DbSet<SecaoRodape> SecoesRodape { get; set; }
        public DbSet<SecaoWeb> SecoesWeb { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<StatusMissao> StatusMissoes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TipoConquista> TiposConquista { get; set; }
        public DbSet<TipoMateria> TiposMateria { get; set; }
        public DbSet<TipoMissao> TiposMissao { get; set; }
        public DbSet<TipoNpc> TiposNpc { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach (var relationship in builder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}			

		}
       
    }
}
