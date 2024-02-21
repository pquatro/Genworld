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
    public class TipoMateriaConfiguration : IEntityTypeConfiguration<TipoMateria>
    {
        public void Configure(EntityTypeBuilder<TipoMateria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Ativo).IsRequired(false).HasDefaultValue(true);
           

            //builder.HasMany<Materia>(e => e.Materias).WithOne(e => e.TipoMateria).HasForeignKey(e => e.TipoMateriaId);
        }
    }
}
