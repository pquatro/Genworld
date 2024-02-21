using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class PersonagemConfiguration : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            builder.UseTpcMappingStrategy();
        }
    }
}
