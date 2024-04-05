


//using Visit.Domain.Enums;

//namespace Visit.Infrastructure.Data.Configurations
//{
//   public class DoctorConfiguration :IEntityTypeConfiguration<Doctor>
//    {
//        public void Configure (EntityTypeBuilder<Doctor> builder)
//        {
//            // Déf clé primaire
//            builder.HasKey(d => d.Id);

//            // Configuration des propriétés
//            builder.Property(wi => wi.FirstName).HasMaxLength(50)
//              .IsRequired();

//            builder.Property(wi => wi.LastName).HasMaxLength(50)
//                .IsRequired();

//            builder.Property(wi => wi.DateOfBirth)
//                .IsRequired();

//            builder.Property(mi => mi.Gender).HasDefaultValue(Gender.Other).
//                HasConversion(
//                mi => mi.ToString(),
//                gender => (Gender)Enum.Parse(typeof(Gender), gender));

//            builder.Property(i => i.Specialty).HasDefaultValue(Specialty.Other).
//                HasConversion(
//                mi => mi.ToString(),
//                specialty => (Specialty)Enum.Parse(typeof(Specialty), specialty));
//        }
//    }
//}
