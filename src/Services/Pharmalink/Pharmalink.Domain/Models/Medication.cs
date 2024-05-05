namespace Pharmalink.Domain.Models


{
    public class Medication : Aggregate<MedicationId>
    {
        public string? Name { get; private set; } = default!;
        public string Dosage { get; private set; } = default!;
        public string? Form { get; private set; } = default!;
        public string? Code { get; private set; } = default!;
        public string? Unit { get; private set; } = default!;
        public string? Description { get; private set; } = default!;
        public DateTime ExpiredAt { get; private set; } = default!;
        public int Stock { get; private set; } = default!;
        public int AlertStock { get; private set; } = default!;
        public int AvrgStock { get; private set; } = default!;
        public int MinStock { get; private set; } = default!;
        public int SafetyStock { get; private set; } = default!;
        public int AvailableStock
        {
            get => Stock - ReservedStock;
            private set { }
        }
        public int ReservedStock { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;

        // Indexing multi-columns
        [NotMapped]
        public string FullTextSearchIndex => $"{Name}{Dosage}{Form}{Code}{Unit}{Description}";
        public static Medication Create(
            MedicationId id,
            string name,
            string dosage,
            string form,
            string code,
            string unit,
            string description,
            DateTime expiredAt,
            int stock,
            int alertStock,
            int avrgStock,
            int minStock,
            int safetyStock,
            int reservedStock,
            decimal price)
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

            medication.AvailableStock = medication.Stock - medication.ReservedStock;

            medication.AddDomainEvent(new MedicationCreatedEvent(medication));
            return medication;
        }

        public void UpdateStock(int stock)
        {
            if (stock < 0)
                throw new DomainException(nameof(UpdateStock) + " : Stock must be greater than 0, error value : " + stock);
            Stock = stock;
        }

    }
}
