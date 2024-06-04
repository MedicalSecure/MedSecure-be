namespace UnitCare.Infrastructure.Data.Configurations;


public class PersonnelConfiguration : IEntityTypeConfiguration<Personnel>
{
    public void Configure(EntityTypeBuilder<Personnel> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
               .HasConversion(personnelId => personnelId.Value,
                              dbId => PersonnelId.Of(dbId));

        builder.HasOne<Domain.Models.UnitCare>()
               .WithMany(p => p.Personnels)
               .HasForeignKey(u => u.UnitCareId);

        builder.Property(p => p.Name)
              .IsRequired();

        builder.Property(r => r.Shift)
            .HasConversion(
            dt => dt.ToString(),
            Shift => (Shift)Enum.Parse(typeof(Shift), Shift));
    }
}

