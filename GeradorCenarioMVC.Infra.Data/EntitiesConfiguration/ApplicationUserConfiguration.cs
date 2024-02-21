using GeradorCenarioMVC.Infra.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCenarioMVC.Infra.Data.EntitiesConfiguration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(250);
            builder.Property(p => p.LastName).HasMaxLength(250);

            builder.Property(p => p.RecebeEmail).IsRequired(false).HasDefaultValue(false);
            builder.Property(p => p.UltimoAcesso).IsRequired(false);
            builder.Property(p => p.Picture).IsRequired(false);
            //builder.Property(p => p.Perfil).IsRequired(false);


        }
    }
}
