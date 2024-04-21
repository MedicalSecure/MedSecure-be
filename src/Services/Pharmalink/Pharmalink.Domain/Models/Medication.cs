namespace Pharmalink.Domain.Models
{
    public class Medication : Aggregate<MedicationId>
    {
        public string? Name { get; set; } = default!;
        public string? Dosage { get; set; } = default!;
        public string? Form { get; set; } = default!;
        public string? Code { get; set; } = default!;
        public string? Unit { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public DateTime ExpiredAt { get; set; } = default!;
        public int Stock { get; set; } = default!;
        //public int AvailableStock { get => Stock - ReservedStock; }
        public int AlertStock { get; set; } = default!;
        public int AvrgStock { get; set; } = default!;
        public int MinStock { get; set; } = default!;
        public int SafetyStock { get; set; } = default!;
        public int ReservedStock { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public static Medication Create(MedicationId id, string name, string dosage, string form, string code, string unit, string description, DateTime expiredAt,
                                        int stock, int alertStock, int avrgStock, int minStock, int safetyStock, int reservedStock, decimal price)
        {
            var medication = new Medication()
            {
                Id = id,
                Name = name,
                Dosage = dosage,
                Form = form,
                Code = code,
                Unit = unit,
                Description = description,
                ExpiredAt = expiredAt,
                Stock = stock,
                AlertStock = alertStock,
                AvrgStock = avrgStock,
                MinStock = minStock,
                SafetyStock = safetyStock,
                ReservedStock = reservedStock,
                Price = price
            };

            medication.AddDomainEvent(new MedicationCreatedEvent(medication));
            return medication;
        }

    }
}
