using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class StatusMissaoConfiguration : IEntityTypeConfiguration<StatusMissao>
    {
        public void Configure(EntityTypeBuilder<StatusMissao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Ativo).IsRequired(false).HasDefaultValue(true);
            

            //builder.HasMany<Missao>(e => e.Missoes).WithOne(e => e.StatusMissao).HasForeignKey(e => e.StatusMissaoId);
        }
    }
}
