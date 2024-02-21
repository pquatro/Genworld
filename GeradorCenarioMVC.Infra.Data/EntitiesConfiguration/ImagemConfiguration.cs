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
    public class ImagemConfiguration : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Url).HasMaxLength(100).IsRequired();
           
            //builder.HasMany<Campanha>(e => e.Campanhas).WithOne(e => e.Imagem).HasForeignKey(e => e.ImagemId).IsRequired(false);
            builder.HasMany<Mapa>(e => e.Mapas).WithOne(e => e.Imagem).HasForeignKey(e => e.ImagemId).IsRequired(false);
            //builder.HasMany<Npc>(e => e.Npcs).WithOne(e => e.Foto).HasForeignKey(e => e.FotoId).IsRequired(false); ;
        }
    }
}
