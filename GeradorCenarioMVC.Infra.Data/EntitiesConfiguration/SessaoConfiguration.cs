using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class SessaoConfiguration : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {


            builder.HasKey(x => x.Id);
            builder.Property(p => p.Titulo).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(255);
            builder.Property(p => p.DataSessao).IsRequired();
            builder.Property(p => p.Duracao).IsRequired(false);
            builder.Property(p => p.Online).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.Local).IsRequired(false);
            builder.Property(p => p.Vtt).IsRequired(false);
            builder.Property(p => p.YoutubeUrl).IsRequired(false);
			builder.Property(p => p.Recompensa).IsRequired(false);

            			

		    builder.HasOne<Usuario>(e => e.Gm).WithMany(e => e.SessoesGm).HasForeignKey(e => e.GmId);
			builder.HasOne<Campanha>(e => e.Campanha).WithMany(e => e.Sessoes).HasForeignKey(e => e.CampanhaId).IsRequired(false);
			

			//builder.HasOne<Grupo>(e => e.Grupo).WithMany(e => e.Sessoes).HasForeignKey(e => e.GrupoId).IsRequired(false);
			//builder.HasOne<Enredo>(e => e.Enredo).WithMany(e => e.Sessoes).HasForeignKey(e => e.EnredoId);

		}
    }
}
