using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Prescription.Infrastructure.Database.Configurations
{
    public class DietConfiguration : IEntityTypeConfiguration<DietForPrescription>
    {
        public void Configure(EntityTypeBuilder<DietForPrescription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
            .HasConversion(DispenseId => DispenseId.Value,
                               dbId => DietForPrescriptionId.Of(dbId));

            // Configure DietsId as JSON using ValueConverter
            var converter = new ValueConverter<List<Guid>, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<Guid>>(v) ?? new List<Guid>());

            // Create a ValueComparer for List<Guid>
            var comparer = new ValueComparer<List<Guid>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            builder.Property(p => p.DietsId)
                .HasConversion(converter)
                .Metadata.SetValueComparer(comparer);//setvalueComparer
        }
    }
}