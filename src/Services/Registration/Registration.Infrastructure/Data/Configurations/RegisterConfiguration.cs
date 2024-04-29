    using Registration.Domain.ValueObjects;

    namespace Registration.Infrastructure.Data.Configurations
    {
        public class RegisterConfiguration : IEntityTypeConfiguration<Register>
        {
            public void Configure(EntityTypeBuilder<Register> builder)
            {
                builder.HasKey(mi => mi.Id);

                builder.Property(d => d.Id)
                       .HasConversion(registerId => registerId.Value,
                                      dbId => RegisterId.Of(dbId));

            builder.OwnsOne(b => b.Patient, patient =>
            {
                patient.Property(p => p.Id).IsRequired()
                 .HasConversion(bpModelid => bpModelid.Value,
                                  dbId => PatientId.Of(dbId)); ;
                                patient.Property(p => p.DateOfBirth).IsRequired();

            });
        }

        }
    }