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
    public class SecaoWebConfiguration : IEntityTypeConfiguration<SecaoWeb>
    {
        public void Configure(EntityTypeBuilder<SecaoWeb> builder)
        {
            builder.UseTpcMappingStrategy();
        }
    }
}
