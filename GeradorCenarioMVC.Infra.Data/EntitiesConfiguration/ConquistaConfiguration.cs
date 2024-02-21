using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class ConquistaConfiguration : IEntityTypeConfiguration<Conquista>
    {
        public void Configure(EntityTypeBuilder<Conquista> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Titulo).HasMaxLength(50).IsRequired();            
            builder.HasOne<TipoConquista>(e => e.TipoConquista).WithMany(e => e.Conquistas).HasForeignKey(e => e.TipoConquistaId);

        }
    }
}
