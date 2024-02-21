using GeradorCenarioMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class CategoriaMateriaConfiguration : IEntityTypeConfiguration<CategoriaMateria>
    {
        public void Configure(EntityTypeBuilder<CategoriaMateria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Ativo).IsRequired(false).HasDefaultValue(true);
            

            //builder.HasMany<CategoriaMateria>(e => e.SubCategoriasMateria).WithOne(e => e.Parent).HasForeignKey(e => e.ParentId).IsRequired(false);



        }
    }
}
