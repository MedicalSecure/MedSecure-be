using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Prescription.Infrastructure.Database.Configurations
{
    //called from : ApplicationDbContext :
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Domain.Entities.Prescription>
    {
        public PrescriptionConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Domain.Entities.Prescription> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
            .HasConversion(PrescriptionId => PrescriptionId.Value,
               dbId => PrescriptionId.Of(dbId));

            builder.Property(p => p.BedId)
            .HasConversion(
                new ValueConverter<EquipmentId?, Guid?>(
                    modelDietId => modelDietId == null ? null : modelDietId.Value,
                    dbEquipmentId => dbEquipmentId.HasValue ? EquipmentId.OfNullable(dbEquipmentId.Value) : null
                ),
                new ValueComparer<EquipmentId?>(
                    (equipmentId1, equipmentId2) => equipmentId1 == null && equipmentId2 == null || equipmentId1 != null && equipmentId2 != null && equipmentId1.Value == equipmentId2.Value,
                    equipmentId => equipmentId == null ? 0 : equipmentId.Value.GetHashCode(),
                    equipmentId => equipmentId ?? EquipmentId.Of(Guid.Empty)
                )
            );

            builder.Property(p => p.RegisterId)
            .HasConversion(registedId => registedId.Value,
                   dbId => RegisterId.Of(dbId));

            builder.Property(p => p.DoctorId)
            .HasConversion(doctorId => doctorId.Value,
               dbId => DoctorId.Of(dbId));

            builder.HasMany(Prescription => Prescription.Symptoms)
                .WithMany(Sym => Sym.Prescriptions);

            builder.HasMany(Prescription => Prescription.Diagnosis)
                .WithMany(diag => diag.Prescriptions);

            builder.HasMany(Prescription => Prescription.Posology)
                .WithOne(Posology => Posology.Prescription);

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);

            builder.Property(r => r.Status)
                .HasConversion(
                dt => dt.ToString(),
                status => (PrescriptionStatus)Enum.Parse(typeof(PrescriptionStatus), status));
            // Ignore the circular reference
            //builder.Navigation(p => p.Register).AutoInclude(false);
            //builder.Navigation(p => p.Doctor).AutoInclude(false);
        }
    }
}