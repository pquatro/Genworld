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
    public class MateriaConfiguration : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            //builder.HasKey(x => x.Id);
            builder.Property(p => p.Titulo).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Peso).HasPrecision(10, 2).IsRequired(false);
           

            builder.Property(p => p.ConteudoRestrito).IsRequired(false).HasDefaultValue(false);
            builder.Property(p => p.ExibirAutorTopo).IsRequired(false).HasDefaultValue(false);
            builder.Property(p => p.PermitirComentario).IsRequired(false).HasDefaultValue(false);
            builder.Property(p => p.Icone).IsRequired(false);


            builder.ToTable("Materias");

            builder.HasOne<SecaoCabecalho>(e => e.SecaoCabecalho).WithMany(e => e.Materias).HasForeignKey(e => e.SecaoCabecalhoId).IsRequired(false); 
            builder.HasOne<SecaoRodape>(e => e.SecaoRodape).WithMany(e => e.Materias).HasForeignKey(e => e.SecaoRodapeId).IsRequired(false); 
            builder.HasOne<SecaoLateral>(e => e.SecaoLateral).WithMany(e => e.Materias).HasForeignKey(e => e.SecaoLateralId).IsRequired(false); 

            builder.HasOne<TipoMateria>(e => e.TipoMateria).WithMany(e => e.Materias).HasForeignKey(e => e.TipoMateriaId);            
            //builder.HasMany<Materia>(e => e.SubMaterias).WithOne(e => e.Parent).HasForeignKey(e => e.ParentId).IsRequired(false).IsRequired(false);

        }
    }
}
