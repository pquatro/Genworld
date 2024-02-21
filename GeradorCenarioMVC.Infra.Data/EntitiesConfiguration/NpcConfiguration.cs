using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class NpcConfiguration : IEntityTypeConfiguration<Npc>
    {
        public void Configure(EntityTypeBuilder<Npc> builder)
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
            builder.Property(p => p.NotasSecretas).IsRequired(false);
            builder.Property(p => p.Visivel).IsRequired(false).HasDefaultValue(true);
           

            builder.ToTable("Npcs");

            builder.HasOne<TipoNpc>(e => e.TipoNpc).WithMany(e => e.Npcs).HasForeignKey(e => e.Id);
            //builder.HasOne<Imagem>(e => e.Foto).WithMany(e => e.Npcs).HasForeignKey(e => e.FotoId).IsRequired(false);
            //builder.HasOne<Grupo>(e => e.Grupo).WithMany(e => e.NPCs).HasForeignKey(e => e.GrupoId).IsRequired(false);
            
        }
    }
}
