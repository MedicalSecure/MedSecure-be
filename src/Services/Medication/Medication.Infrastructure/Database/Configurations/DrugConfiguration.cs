namespace Medication.Infrastructure.Database.Configurations;

public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> builder)
    {

        builder.HasKey(d => d.Id);


        builder.Property(d => d.Id)
            .HasConversion(
                drugId => drugId.Value,
                dbId => DrugId.Of(dbId));


        builder.Property(d => d.Name)
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(d => d.Dosage)
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(d => d.Form)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(d => d.Code)
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(d => d.Unit)
            .HasMaxLength(20)
            .IsRequired();


        builder.Property(d => d.Description)
            .IsRequired();


        builder.Property(d => d.ExpiredAt)
            .IsRequired();


        builder.Property(d => d .Stock)
            .IsRequired();

        builder.Property(d => d.AlertStock)
            .IsRequired();

        builder.Property(d => d.AvrgStock)
            .IsRequired();

        builder.Property(d => d.MinStock)
            .IsRequired();

        builder.Property(d => d.SafetyStock)
            .IsRequired();

        builder.Property(d => d.AvailableStock)
            .IsRequired()
            .HasComputedColumnSql("[Stock] - [ReservedStock]");

        builder.Property(d => d  .ReservedStock)
            .IsRequired();

        builder.Property(d => d.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }
}
