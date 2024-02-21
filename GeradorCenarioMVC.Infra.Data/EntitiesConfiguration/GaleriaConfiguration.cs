using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class GaleriaConfiguration : IEntityTypeConfiguration<Galeria>
    {
        public void Configure(EntityTypeBuilder<Galeria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
           
            //builder.HasMany<Cenario>(e => e.Cenarios).WithOne(e => e.Galeria).HasForeignKey(e => e.GaleriaId).IsRequired(false);
            //builder.HasOne<Pc>(e => e.Pc).WithOne(e => e.Galeria).HasForeignKey<Pc>(e => e.GaleriaId).IsRequired(false);            
            //builder.HasOne<SecaoRodape>(e => e.SecaoRodape).WithOne(e => e.Galeria).HasForeignKey<SecaoRodape>(e => e.GaleriaId).IsRequired(false);
        }
    }
}
