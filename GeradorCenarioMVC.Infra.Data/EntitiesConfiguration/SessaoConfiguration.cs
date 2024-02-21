using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class SessaoConfiguration : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {


            builder.HasKey(x => x.Id);
            builder.Property(p => p.Titulo).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(255);
            builder.Property(p => p.Data).IsRequired();
            builder.Property(p => p.DuracaoHoras).IsRequired(false);
            builder.Property(p => p.JogoOnline).IsRequired(false).HasDefaultValue(false);
            builder.Property(p => p.Local).IsRequired(false);
            builder.Property(p => p.Vtt).IsRequired(false);
            builder.Property(p => p.YoutubeUrl).IsRequired(false);
           


            builder.HasOne<Usuario>(e => e.Gm).WithMany(e => e.Sessoes).HasForeignKey(e => e.GmId);
            builder.HasOne<Grupo>(e => e.Grupo).WithMany(e => e.Sessoes).HasForeignKey(e => e.GrupoId).IsRequired(false);
            builder.HasOne<Enredo>(e => e.Enredo).WithMany(e => e.Sessoes).HasForeignKey(e => e.EnredoId);
            
        }
    }
}
