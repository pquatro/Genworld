using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class EnredoConfiguration : IEntityTypeConfiguration<Enredo>
    {
        public void Configure(EntityTypeBuilder<Enredo> builder)
        {
            //builder.HasKey(x => x.Id);
            builder.Property(p => p.Titulo).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();            
            builder.Property(p => p.Introducao).IsRequired();
            builder.Property(p => p.PlanoFundo).IsRequired();
            builder.Property(p => p.VisaoGeral).IsRequired();
            builder.Property(p => p.GanchoPersonagens).IsRequired();
            builder.Property(p => p.Conclusao).IsRequired();
            builder.Property(p => p.Aliados).IsRequired(false);
           


            builder.ToTable("Enredos");

            //builder.HasOne<Sessao>(e => e.Sessao).WithOne(e => e.Enredo).HasForeignKey<Sessao>(e => e.Id).IsRequired(false);
            //builder.HasOne<Campanha>(e => e.Campanha).WithMany(e => e.Enredos).HasForeignKey(e => e.Id);






        }
    }
}
