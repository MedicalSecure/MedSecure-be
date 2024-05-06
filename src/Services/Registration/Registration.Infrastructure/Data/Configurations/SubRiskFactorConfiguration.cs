namespace Registration.Infrastructure.Data.Configurations
{
    public class SubRiskFactorConfiguration : IEntityTypeConfiguration<SubRiskFactor>
    {
        public void Configure(EntityTypeBuilder<SubRiskFactor> builder)
        {

            builder.HasKey(r => r.Id);

            builder.Property(d => d.Id)
                   .HasConversion(subRiskFactorId => subRiskFactorId.Value,
                                  dbId => SubRiskFactorId.Of(dbId));

            builder.HasOne<RiskFactor>()
             .WithMany(d => d.SubRiskfactor)
                   .HasForeignKey(w => w.RiskFactorId).IsRequired();

            builder.Property(wi => wi.Key)
                   .IsRequired();

            builder.Property(wi => wi.Value)
                   .IsRequired();
        }
    }
}
