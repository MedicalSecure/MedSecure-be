namespace Registration.Infrastructure.Data.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Code)
                   .IsRequired()
                   .HasMaxLength(100); // Adjust the maximum length as needed

            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(255); // Adjust the maximum length as needed

            // Assuming Language is an enum
            builder.Property(t => t.Language)
                   .IsRequired()
                   .HasConversion<int>();

            // Assuming TestType is an enum
            builder.Property(t => t.Type)
                   .IsRequired()
                   .HasConversion<int>();
        }
    }
}
