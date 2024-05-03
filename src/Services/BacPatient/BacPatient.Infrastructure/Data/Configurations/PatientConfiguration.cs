

namespace BacPatient.Infrastructure.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(mi => mi.Id);

            builder.Property(mi => mi.Id);
               
        }
    }
}
