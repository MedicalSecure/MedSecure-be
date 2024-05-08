﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Prescription.Infrastructure.Database.Configurations
{
    //called from : ApplicationDbContext :
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Domain.Entities.PrescriptionRoot.Prescription>
    {
        public PrescriptionConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Domain.Entities.PrescriptionRoot.Prescription> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
            .HasConversion(PrescriptionId => PrescriptionId.Value,
               dbId => PrescriptionId.Of(dbId));

            /*            builder.Property(p => p.DietId)
                    .HasConversion(dietId => dietId.Value,
                           dbId => DietId.Of(dbId));*/

            builder.Property(p => p.DietId)
            .HasConversion(
                new ValueConverter<DietId?, Guid?>(
                    modelDietId => modelDietId == null ? null : modelDietId.Value,
                    dbDietId => dbDietId.HasValue ? DietId.OfNullable(dbDietId.Value) : null
                ),
                new ValueComparer<DietId?>(
                    (dietId1, dietId2) => dietId1 == null && dietId2 == null || dietId1 != null && dietId2 != null && dietId1.Value == dietId2.Value,
                    dietId => dietId == null ? 0 : dietId.Value.GetHashCode(),
                    dietId => dietId ?? DietId.Of(Guid.Empty)
                )
            );

            builder.Property(p => p.UnitCareId)
            .HasConversion(
                new ValueConverter<UnitCareId?, Guid?>(
                    modelDietId => modelDietId == null ? null : modelDietId.Value,
                    dbDietId => dbDietId.HasValue ? UnitCareId.OfNullable(dbDietId.Value) : null
                ),
                new ValueComparer<UnitCareId?>(
                    (unitCareId1, unitCareId2) => unitCareId1 == null && unitCareId2 == null || unitCareId1 != null && unitCareId2 != null && unitCareId1.Value == unitCareId2.Value,
                    unitCareId => unitCareId == null ? 0 : unitCareId.Value.GetHashCode(),
                    unitCareId => unitCareId ?? UnitCareId.Of(Guid.Empty)
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
            // Ignore the circular reference
            //builder.Navigation(p => p.Register).AutoInclude(false);
            //builder.Navigation(p => p.Doctor).AutoInclude(false);
        }
    }
}