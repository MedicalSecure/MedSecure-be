

namespace BacPatient.Infrastructure.Data.Configurations
{
    public class RiskFactorConfiguration : IEntityTypeConfiguration<RiskFactor>
    {
        public void Configure(EntityTypeBuilder<RiskFactor> builder)
        {

            builder.HasKey(r => r.Id);
           


        }
    }
}
