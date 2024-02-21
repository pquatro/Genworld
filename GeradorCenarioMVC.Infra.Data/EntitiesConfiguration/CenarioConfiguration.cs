using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class CenarioConfiguration : IEntityTypeConfiguration<Cenario>
    {
        public void Configure(EntityTypeBuilder<Cenario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Peso).HasPrecision(10, 2).IsRequired(false);
            builder.Property(p => p.Privado).IsRequired(false);
            builder.Property(p => p.DataCenario).IsRequired(false);
            builder.Property(p => p.CenarioOficial).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.SistemaOficial).HasMaxLength(50).IsRequired(false);
           
            builder.HasOne<Galeria>(e => e.Galeria).WithMany(e => e.Cenarios).HasForeignKey(x => x.GaleriaId).IsRequired(false);
            //builder.HasMany<Campanha>(e => e.Campanhas).WithOne(e => e.Cenario).HasForeignKey(e => e.CenarioId).IsRequired(false);            
            //builder.HasMany<Mapa>(e => e.Mapas).WithOne(e => e.Cenario).HasForeignKey(e => e.CenarioId).IsRequired(false);

        }
    }
}
