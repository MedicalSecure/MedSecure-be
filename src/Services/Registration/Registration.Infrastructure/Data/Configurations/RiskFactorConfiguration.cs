namespace Registration.Infrastructure.Data.Configurations
{
    public class RiskFactorConfiguration : IEntityTypeConfiguration<RiskFactor>
    {
        public void Configure(EntityTypeBuilder<RiskFactor> builder)
        {
            builder.HasKey(r => r.Id);

            // Configure primary key to use Value property of RiskFactorId
            builder.Property(r => r.Id)
                   .HasConversion(riskFactorId => riskFactorId.Value,
                                  dbId => RiskFactorId.Of(dbId));

            // Configure many-to-one relationship with Register for Disease
            builder.HasOne<Register>()
                   .WithMany(r => r.Disease)
                   .HasForeignKey(rf => rf.RegisterIdForDisease)
                   .IsRequired();

            // Configure many-to-one relationship with Register for Allergy
            builder.HasOne<Register>()
                   .WithMany(r => r.Allergy)
                   .HasForeignKey(rf => rf.RegisterIdForAllergy)
                   .IsRequired();

            // Configure many-to-one relationship with Register for FamilyMedicalHistory
            builder.HasOne<Register>()
                   .WithMany(r => r.FamilyMedicalHistory)
                   .HasForeignKey(rf => rf.RegisterIdForFamilyMedicalHistory)
                   .IsRequired();

            // Configure many-to-one relationship with Register for PersonalMedicalHistory
            builder.HasOne<Register>()
                   .WithMany(r => r.PersonalMedicalHistory)
                   .HasForeignKey(rf => rf.RegisterIdForPersonalMedicalHistory)
                   .IsRequired();

            // Configure Key and Value properties to be required
            builder.Property(rf => rf.Key)
                   .IsRequired();

            builder.Property(rf => rf.Value)
                   .IsRequired();
        }
    }
}
