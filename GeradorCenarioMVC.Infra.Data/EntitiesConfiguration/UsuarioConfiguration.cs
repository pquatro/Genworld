using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.UserId).HasMaxLength(450).IsRequired();            
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Sobrenome).HasMaxLength(50).IsRequired();            
            builder.Property(p => p.Email).HasMaxLength(100).IsRequired();            
            builder.Property(p => p.EmailVerificado).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.RecebeEmail).IsRequired(false).HasDefaultValue(false);
            builder.Property(p => p.UltimoAcesso).IsRequired(false);
            builder.Property(p => p.Ativo).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.FotoBytes).IsRequired(false);
			builder.Property(p => p.PerfilId).IsRequired();
			

			//builder.HasMany<Campanha>(e => e.Campanhas).WithOne(e => e.CriadoPor).HasForeignKey(e => e.CriadoPorId).IsRequired(false);
			//builder.HasMany<Campanha>(e => e.Campanhas).WithOne(e => e.Mestre).HasForeignKey(e => e.MestreId).IsRequired(false);


		}
    }
}
