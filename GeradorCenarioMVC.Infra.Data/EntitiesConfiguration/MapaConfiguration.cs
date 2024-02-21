using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class MapaConfiguration : IEntityTypeConfiguration<Mapa>
    {
        public void Configure(EntityTypeBuilder<Mapa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Titulo).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Peso).HasPrecision(10, 2).IsRequired(false);
            builder.Property(p => p.Legenda).HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.ExibirHomepageCenario).IsRequired(false).HasDefaultValue(false);
            builder.Property(p => p.Publico).IsRequired(false).HasDefaultValue(false);
           

            builder.HasOne<Imagem>(e => e.Imagem).WithMany(e => e.Mapas).HasForeignKey(e => e.ImagemId);
            builder.HasOne<Cenario>(e => e.Cenario).WithMany(e => e.Mapas).HasForeignKey(e => e.CenarioId);
            builder.HasOne<Materia>(e => e.Organizacao).WithMany(e => e.OrganizacaoMapas).HasForeignKey(e => e.OrganizacaoId).IsRequired(false);
            builder.HasOne<Materia>(e => e.Localizacao).WithMany(e => e.LocalizacaoMapas).HasForeignKey(e => e.LocalizacaoId).IsRequired(false);

        }
    }
}
