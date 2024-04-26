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

            builder.HasOne<Patient>()
             .WithMany()
             .HasForeignKey(w => w.PatientId);
        }

    }
}