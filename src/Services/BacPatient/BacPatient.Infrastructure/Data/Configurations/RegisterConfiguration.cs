namespace BacPatient.Infrastructure.Data.Configurations
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasKey(r => r.Id);

            // Configure primary key to use Value property of RegisterId
            builder.Property(r => r.Id)
                   ;

            // Configure one-to-many relationship with Patient
            builder.HasOne(r => r.Patient)
                   .WithMany()
                   .HasForeignKey(r => r.PatientId);
        }
    }
}