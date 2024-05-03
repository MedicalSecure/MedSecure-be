
    namespace BacPatient.Infrastructure.Data.Configurations
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasKey(mi => mi.Id);
           




        }

    }
}