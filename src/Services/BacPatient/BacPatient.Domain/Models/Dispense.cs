namespace BacPatient.Domain.Models
{
    public class Dispense : Entity<Guid>
    {
        public int Hour { get; private set; }

        public int? QuantityBE { get; private set; } // Nullable int for Before Meals
        public int? QuantityAE { get; private set; } // Nullable int for After Meals

        public Guid PosologyId { get; private set; }
        public Posology? posology { get; private set; }

        private Dispense()
        { } // Required for EF Core

        private Dispense(Guid id, Guid posologyId, int hour, int? quantityBE, int? quantityAE)
        {
            Validator.isHourValid(hour, nameof(hour));

            if (quantityBE == null && quantityAE == null)
            {
                throw new ArgumentException("At least one of QuantityBE or QuantityAE must be provided.");
            }

            Id = id;
            PosologyId = posologyId;
            Hour = hour;
            QuantityBE = quantityBE;
            QuantityAE = quantityAE;
        }

        public static Dispense Create(Guid posologyId, int hour, int? quantityBE, int? quantityAE)
        {
            return new Dispense(new Guid(), posologyId, hour, quantityBE, quantityAE);
        }
        public static Dispense Create(Guid Id, Guid posologyId, int hour, int? quantityBE, int? quantityAE)
        {
            return new Dispense(Id, posologyId, hour, quantityBE, quantityAE);
        }
    }
}