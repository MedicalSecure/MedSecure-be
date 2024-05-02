namespace BacPatient.Domain.Models
{
    public class Medication : Aggregate<Guid>
    {
        public string? Name { get; private set; } = default!;
        public string? Dosage { get; private set; } = default!;
        public string? Form { get; private set; } = default!;
        public string? Unit { get; private set; } = default!;
        public string? Description { get; private set; } = default!;
        public string? Code { get; private set; } = default!;
        public DateTime ExpiredAt { get; private set; } = default!;
        public int Stock { get; private set; } = default!;
        public int AlertStock { get; private set; } = default!;
        public int AvrgStock { get; private set; } = default!;
        public int MinStock { get; private set; } = default!;
        public int SafetyStock { get; private set; } = default!;
        public int ReservedStock { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;


        private Medication()
        { } 

        public static Medication Create(Guid id, string name, string dosage, string form, string unit, string description, string code, DateTime expiredAt,
                                        int stock, int alertStock, int avrgStock, int minStock, int safetyStock, int reservedStock, decimal price )
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
            return medication;
        }


    }
}