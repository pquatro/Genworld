using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace GeradorCenarioMVC.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opttions) : base(opttions) {	}

        public DbSet<Campanha> Campanhas { get; set; }
		public DbSet<Genero> Generos { get; set; }
		public DbSet<Imagem> Imagens { get; set; }      
        public DbSet<Sessao> Sessoes { get; set; }       
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
