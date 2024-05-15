namespace BacPatient.Domain.Models
{
    public class Medication : Aggregate<MedicationId>
    {
        public string? Name { get; private set; } = default!;
        public string? Dosage { get; private set; } = default!;
        public Route? Form { get; private set; } = default!;
        public string? Unit { get; private set; } = default!;
        public string? Description { get; private set; } = default!;
        public string? Code { get; private set; } = default!;
        public DateTime? ExpiredAt { get; private set; } = default!;
        public int? Stock { get; private set; } = default!;
        public int? AlertStock { get; private set; } = default!;
        public int? AvrgStock { get; private set; } = default!;
        public int? MinStock { get; private set; } = default!;
        public int? SafetyStock { get; private set; } = default!;
        public int? ReservedStock { get; private set; } = default!;
        public decimal? Price { get; private set; } = default!;

        private Medication()
        { } // For EF

        private Medication  ( MedicationId id ,string name , Route forme , string description )
        {
            Id = id;
            Name = name;
            Form = forme;
            Description = description;
           
        }

        public Medication(MedicationId Id, string Name, string Dosage, Route? Form, string Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Dosage = Dosage;
            this.Form = Form;
            this.Description = Description;
        }

        public static Medication Create(string name, Route forme, string description)
        {
            MedicationId id = MedicationId.Of(Guid.NewGuid());

            return new Medication(id, name, forme, description);
        }
        public static Medication Create(MedicationId id, string name, string dosage, Route form, string unit, string description, string code, DateTime expiredAt,
                                        int stock, int alertStock, int avrgStock, int minStock, int safetyStock, int reservedStock, decimal price)
        {
            var medication = new Medication()
            {
                Id = id,
                Name = name,
                Dosage = dosage,
                Form = form,
                Unit = unit,
                Description = description,
                Code = code,
                ExpiredAt = expiredAt,
                Stock = stock,
                AlertStock = alertStock,
                AvrgStock = avrgStock,
                MinStock = minStock,
                SafetyStock = safetyStock,
                ReservedStock = reservedStock,
                Price = price
            };
            //medication.AddDomainEvent(new MedicationCreatedEvent(medication));
            return medication;
        }
    }
}