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
    public class MissaoConfiguration : IEntityTypeConfiguration<Missao>
    {
        public void Configure(EntityTypeBuilder<Missao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Titulo).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Resumo).IsRequired();
            builder.Property(p => p.Resolucao).IsRequired(false);
            builder.Property(p => p.NotasSecretas).IsRequired(false);
           


            builder.HasOne<StatusMissao>(e => e.StatusMissao).WithMany(e => e.Missoes).HasForeignKey(e => e.StatusMissaoId);
            builder.HasOne<TipoMissao>(e => e.TipoMissao).WithMany(e => e.Missoes).HasForeignKey(e => e.TipoMissaoId);
           
        }
    }
}
