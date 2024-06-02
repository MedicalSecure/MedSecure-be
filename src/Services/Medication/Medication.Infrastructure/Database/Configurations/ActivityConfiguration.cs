namespace Medication.Infrastructure.Database.Configurations;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(d => d.Content)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(d => d.CreatorName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(d => d.CreatedAt)
            .IsRequired();
    }
}
