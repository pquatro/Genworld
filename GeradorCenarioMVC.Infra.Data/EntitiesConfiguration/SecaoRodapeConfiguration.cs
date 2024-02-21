using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class SecaoRodapeConfiguration : IEntityTypeConfiguration<SecaoRodape>
    {
        public void Configure(EntityTypeBuilder<SecaoRodape> builder)
        {
            //builder.HasKey(x => x.Id);
            builder.Property(p => p.Css).HasMaxLength(100).IsRequired(false);
            builder.Property(p => p.NotaRodape).IsRequired(false);
            builder.Property(p => p.NotaAutor).IsRequired(false);
            builder.Property(p => p.Comentarios).IsRequired(false);
            


            builder.ToTable("SecoesRodape");

            builder.HasOne<Galeria>(e => e.Galeria).WithMany(e => e.SecoesRodape).HasForeignKey(e => e.GaleriaId);
            //builder.HasMany<Materia>(e => e.Materias).WithOne(e => e.SecaoRodape).HasForeignKey(e => e.SecaoRodapeId);
        }

    }
}
