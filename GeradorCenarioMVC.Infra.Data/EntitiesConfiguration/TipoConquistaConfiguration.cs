using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class TipoConquistaConfiguration : IEntityTypeConfiguration<TipoConquista>
    {
        public void Configure(EntityTypeBuilder<TipoConquista> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Ativo).IsRequired(false).HasDefaultValue(true);
            
            
        }
    }
}
