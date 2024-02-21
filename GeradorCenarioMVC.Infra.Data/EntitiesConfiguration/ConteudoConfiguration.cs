using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class ConteudoConfiguration : IEntityTypeConfiguration<Conteudo>
    {
        public void Configure(EntityTypeBuilder<Conteudo> builder)
        {
            builder.UseTpcMappingStrategy();
        }
    }
}
