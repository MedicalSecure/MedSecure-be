
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visit.Domain.Enums;
using Visit.Domain.Models;
using Visit.Domain.ValueObjects;

namespace Visit.Infrastructure.Data.Configurations;

public class VisitConfiguration :IEntityTypeConfiguration<Domain.Models.Visit>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Visit> builder)
    {
        //def cle primaire
        builder.HasKey(i => i.Id);
        //configuration proprety id
        builder.Property(i =>i.Id)
            .HasConversion(visitId=> visitId.Value,
            dbId=> VisitId.Of(dbId));
        // Configuration de la relation 1=>* avec DoctorId
        //builder.HasOne(i => i.DoctorId)
        //       .WithMany();

        builder.Property(i => i.DoctorId)
                .IsRequired() // Assuming DoctorId is required
                .HasConversion(doctorId => doctorId.Value,
            dbId => DoctorId.Of(dbId));


        // Configuration de la relation *=>* avec PatientId
        //builder.HasMany(i => i.PatientId)
        //       .WithMany();



        // Configuration de la relation *=>* avec PatientId
        //builder.HasMany(i => i.PatientId)
        //       .WithMany();


        builder.HasOne<Patient>()
              .WithMany()
              .HasForeignKey(w => w.PatientId);

        //configuration proprety
        builder.Property(i => i.StartDate).IsRequired();
        builder.Property(i => i.EndDate).IsRequired();
        builder.Property(i => i.Title).IsRequired();
        builder.Property(i => i.TypeVisit).IsRequired();
            //HasConversion(
            //dt => dt.ToString(),
            //dietType => (TypeVisit)Enum.Parse(typeof(TypeVisit), dietType));
        builder.Property(i => i.LocationVisit).IsRequired();
        builder.Property(i => i.Duration).IsRequired();
        builder.Property(i => i.Description).IsRequired();
        builder.Property(i => i.Availability).IsRequired();

    }
 
}
