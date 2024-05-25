namespace BacPatient.Domain.Models
{
    public class Dispense : Entity<DispenseId>
    {
        public string Hour { get; private set; }
        public Dose? BeforeMeal { get; private set; }
        public Dose? AfterMeal { get; private set; }
        public PosologyId PosologyId { get; private set; }
        public Posology? Posology { get; private set; }

        private Dispense()
        { } // Required for EF Core
        public Dispense(DispenseId id , string hour , Dose? beforeMeal , Dose? aftereMeal)
        {
            Id = id;
             Hour = hour;
            BeforeMeal = beforeMeal;
            AfterMeal = aftereMeal;
        }
        private Dispense(DispenseId id,PosologyId posologyId, string hour, Dose? beforeMeal, Dose? aftereMeal)
        {
           

            Id = id;
            PosologyId = posologyId;
            Hour = hour;
            BeforeMeal = beforeMeal;
            AfterMeal = aftereMeal;
        }

        public static Dispense Create(PosologyId posologyId, string? hour, Dose? quantityBE, Dose? quantityAE)
        {
            return new Dispense(DispenseId.Of(Guid.NewGuid()), posologyId, hour, quantityBE, quantityAE);
        }
        public static Dispense Create(DispenseId Id,PosologyId posologyId, string hour, Dose? quantityBE, Dose? quantityAE)
        {
            return new Dispense(Id,posologyId, hour, quantityBE, quantityAE);
        }
    }
}