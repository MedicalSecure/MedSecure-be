namespace Registration.Infrastructure.Data.Configurations;

public class SubRiskFactorConfiguration : IEntityTypeConfiguration<SubRiskFactor>
{
    public void Configure(EntityTypeBuilder<SubRiskFactor> builder)
    {
        builder.HasKey(sr => sr.Id);

        // Configure primary key to use Value property of SubRiskFactorId
        builder.Property(sr => sr.Id)
               .HasConversion(subRiskFactorId => subRiskFactorId.Value,
                              dbId => SubRiskFactorId.Of(dbId));

        // Configure many-to-one relationship with RiskFactor
        builder.HasOne<RiskFactor>()
               .WithMany(r => r.SubRiskFactors) 
               .HasForeignKey(sr => sr.RiskFactorId)
               .IsRequired();

        // Configure Key and Value properties to be required
        builder.Property(sr => sr.Key)
               .IsRequired();

        builder.Property(sr => sr.Value)
               .IsRequired();
    }
}
