using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class SecaoCabecalhoConfiguration : IEntityTypeConfiguration<SecaoCabecalho>
    {
        public void Configure(EntityTypeBuilder<SecaoCabecalho> builder)
        {
            //builder.HasKey(x => x.Id);
            builder.Property(p => p.Css).HasMaxLength(100).IsRequired(false);
            builder.Property(p => p.SubCabecalho).IsRequired(false);
            builder.Property(p => p.Creditos).IsRequired(false);
            

            builder.ToTable("SecoesCabecalho");

            //builder.HasOne<Imagem>(e => e.Imagem).WithMany(e => e.SecoesCabecalho).HasForeignKey(e => e.ImagemId).IsRequired(false);
            //builder.HasMany<Materia>(e => e.Materias).WithOne(e => e.SecaoCabecalho).HasForeignKey(e => e.SecaoCabecalhoId);
        }
    }
}
