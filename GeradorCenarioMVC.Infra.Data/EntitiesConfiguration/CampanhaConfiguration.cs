using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class CampanhaConfiguration : IEntityTypeConfiguration<Campanha>
    {
        public void Configure(EntityTypeBuilder<Campanha> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Introducao).IsRequired(false);
            builder.Property(p => p.Ativo).IsRequired(false).HasDefaultValue(true);           
            


            builder.HasOne<Imagem>(e => e.Imagem).WithMany(e => e.Campanhas).HasForeignKey(x => x.ImagemId).IsRequired(false);
            builder.HasOne<Cenario>(e => e.Cenario).WithMany(e => e.Campanhas).HasForeignKey(e => e.CenarioId);
            //builder.HasMany<Grupo>(e => e.Grupos).WithOne(e => e.Campanha).HasForeignKey(e => e.CampanhaId).IsRequired(false);
            //builder.HasMany<Sessao>(e => e.Sessoes).WithOne(e => e.Campanha).HasForeignKey(e => e.CampanhaId).IsRequired(false);
            //builder.HasMany<Enredo>(e => e.Enredos).WithOne(e => e.Campanha).HasForeignKey(e => e.CampanhaId).IsRequired(false);


        }
    }
}
