namespace Registration.Infrastructure.Data.Configurations
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            //   builder.HasKey(h => h.Id);
            builder.Ignore(h => h.Id);

            builder.Property(h => h.Date)
                   .IsRequired();

            // Assuming Status is an enum
            builder.Property(h => h.Status)
                   .IsRequired()
                   .HasConversion<int>();

          
            // Relationships
            builder.HasOne<Register>()
                   .WithMany(d => d.History)
                   .HasForeignKey(w => w.RegisterId).IsRequired();
        }
    }
}
