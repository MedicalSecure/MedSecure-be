namespace Pharmalink.Infratstructure.Data.Configurations;

public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {

        builder.HasKey(m => m.Id);


        builder.Property(m => m.Id)
            .HasConversion(
                medicationId => medicationId.Value,
                dbId => MedicationId.Of(dbId));


        builder.Property(m => m.Name)
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(m => m.Dosage)
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(m => m.Form)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property (m => m.Code) 
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(m => m.Unit)
            .HasMaxLength(20)
            .IsRequired();


        builder.Property(m => m.Description)
            .IsRequired();


        builder.Property(m => m.ExpiredAt)
            .IsRequired();


        builder.Property(m => m.Stock)
            .IsRequired();

        builder.Property(m => m.AlertStock)
            .IsRequired();

        builder.Property(m => m.AvrgStock)
            .IsRequired();

        builder.Property(m => m.MinStock)
            .IsRequired();

        builder.Property(m => m.SafetyStock)
            .IsRequired();

        builder.Property(m => m.ReservedStock)
            .IsRequired();


        builder.Property(m => m.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }
}
