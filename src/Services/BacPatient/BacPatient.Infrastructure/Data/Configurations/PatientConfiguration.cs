using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
namespace BacPatient.Infrastructure.Data.Configurations
{
    //called from : ApplicationDbContext :
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    public class RiskFactorListConverter : ValueConverter<List<RiskFactor?>, string>
    {
        public RiskFactorListConverter() : base(
            riskFactors => JsonSerializer.Serialize(riskFactors, new JsonSerializerOptions { /* Add any necessary options */ }),
            json => JsonSerializer.Deserialize<List<RiskFactor>>(json, new JsonSerializerOptions { /* Add any necessary options */ })
        )
        {
        }
    }

    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Patient> builder)

        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.PatientName)
                .HasMaxLength(100);
 

      
        }
    }
}