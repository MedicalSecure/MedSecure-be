namespace Registration.Infrastructure.Data.Configurations
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasKey(r => r.Id);

            // Configure primary key to use Value property of RegisterId
            builder.Property(r => r.Id)
                   .HasConversion(registerId => registerId.Value,
                                  dbId => RegisterId.Of(dbId));

            // Configure one-to-many relationship with Patient
            builder.HasOne(r => r.Patient)
                   .WithMany()
                   .HasForeignKey(r => r.PatientId)
                   .IsRequired();

            builder.HasMany(r => r.FamilyMedicalHistory)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RegisterFamilyMedicalHistory",
                    j => j
                        .HasOne<RiskFactor>()
                        .WithMany()
                        .HasForeignKey("RiskFactorId"),
                    j => j
                        .HasOne<Register>()
                        .WithMany()
                        .HasForeignKey("RegisterId")
                );

            builder.HasMany(r => r.PersonalMedicalHistory)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RegisterPersonalMedicalHistory",
                    j => j
                        .HasOne<RiskFactor>()
                        .WithMany()
                        .HasForeignKey("RiskFactorId"),
                    j => j
                        .HasOne<Register>()
                        .WithMany()
                        .HasForeignKey("RegisterId")
                );

            builder.HasMany(r => r.Disease)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RegisterDisease",
                    j => j
                        .HasOne<RiskFactor>()
                        .WithMany()
                        .HasForeignKey("RiskFactorId"),
                    j => j
                        .HasOne<Register>()
                        .WithMany()
                        .HasForeignKey("RegisterId")
                );

            builder.HasMany(r => r.Allergy)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RegisterAllergy",
                    j => j
                        .HasOne<RiskFactor>()
                        .WithMany()
                        .HasForeignKey("RiskFactorId"),
                    j => j
                        .HasOne<Register>()
                        .WithMany()
                        .HasForeignKey("RegisterId")
                );

            builder.HasMany(r => r.History)
                .WithOne()
                .HasForeignKey(h => h.RegisterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Tests)
                .WithOne()
                .HasForeignKey(t => t.RegisterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
        }
    }
}