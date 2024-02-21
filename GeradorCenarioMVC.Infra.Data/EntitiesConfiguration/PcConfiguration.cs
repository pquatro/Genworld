using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class PcConfiguration : IEntityTypeConfiguration<Pc>
    {
        public void Configure(EntityTypeBuilder<Pc> builder)
        {

            //builder.HasKey(x => x.Id);
            builder.Property(p => p.NomePrimeiro).HasMaxLength(50).IsRequired();
            builder.Property(p => p.NomeUltimo).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Apelido).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.Caracteristicas).HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.Introducao).HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.Raca).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.Tendencia).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.Olhos).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.Cabelo).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.Pele).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.Altura).HasPrecision(10, 2).IsRequired(false);
            builder.Property(p => p.Peso).HasPrecision(10, 2).IsRequired(false);
            builder.Property(p => p.Frase).HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.Idade).IsRequired(false);
            builder.Property(p => p.Journal).IsRequired(false);
            builder.Property(p => p.Historia).IsRequired(false);
            
            

            builder.ToTable("Pcs");

            
            builder.HasOne<Usuario>(e => e.Jogador).WithMany(e => e.Pcs).HasForeignKey(e => e.JogadorId);
            builder.HasOne<Galeria>(e => e.Galeria).WithMany(e => e.Pcs).HasForeignKey(e => e.GaleriaId).IsRequired(false);
            builder.HasOne<Imagem>(e => e.Imagem).WithMany(e => e.Pcs).HasForeignKey(e => e.ImagemId).IsRequired(false);
        }
    }
}
