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
    public class SecaoLateralConfiguration : IEntityTypeConfiguration<SecaoLateral>
    {
        public void Configure(EntityTypeBuilder<SecaoLateral> builder)
        {
            //builder.HasKey(x => x.Id);
            builder.Property(p => p.Css).HasMaxLength(100).IsRequired(false);
            builder.Property(p => p.Topo).IsRequired(false);
            builder.Property(p => p.PainelTopo).IsRequired(false);
            builder.Property(p => p.PainelAbaixo).IsRequired(false);
            builder.Property(p => p.Abaixo).IsRequired(false);
            

            builder.ToTable("SecoesLateral");

            //builder.HasMany<Materia>(e => e.Materias).WithOne(e => e.SecaoLateral).HasForeignKey(e => e.SecaoLateralId);
        }
    }
}
