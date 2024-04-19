using Registration.Domain.Models;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrastructure.Data.Configurations
{
    public class RiskFactorConfiguration : IEntityTypeConfiguration<RiskFactor>
    {
        public void Configure(EntityTypeBuilder<RiskFactor> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(wi => wi.Key)
               .IsRequired();

            builder.Property(wi => wi.Value)
                .IsRequired();

            builder.Property(wi => wi.SubRiskfactory)
                .IsRequired();
        }
    }
}
