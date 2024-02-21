using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(255).IsRequired(false);
           

            //builder.HasMany<Pc>(e => e.PCs).WithOne(e => e.Grupo).HasForeignKey(e => e.GrupoId);
            //builder.HasMany<Npc>(e => e.NPCs).WithOne(e => e.Grupo).HasForeignKey(e => e.GrupoId).IsRequired(false); ;
            //builder.HasMany<Sessao>(e => e.Sessoes).WithOne(e => e.Grupo).HasForeignKey(e => e.GrupoId).IsRequired(false);
            //builder.HasOne<Campanha>(e => e.Campanha).WithMany(e => e.Grupos).HasForeignKey(e => e.CampanhaId);

        }
    }
}
