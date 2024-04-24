namespace UnitCare.Domain.Models
{
    public class Personnel : Aggregate<ValueObjects.PersonnelId>
    {
        public UnitCareId UnitCareId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public Shift Shift { get; set; } = default!;

        public static Personnel Create(
            PersonnelId id,
            UnitCareId unitCareId,
            string name,
            Shift shift)
        {
            var personnel = new Personnel()
            {
                Id = id,
                UnitCareId = unitCareId,
                Name = name,
                Shift = shift,
            };

            personnel.AddDomainEvent(new PersonnelCreatedEvent(personnel));

            return personnel;
        }

        public void Update(
            UnitCareId unitCareId,
            string name,
            Shift shift)
        {
            Name = name;
            Shift = shift;
            UnitCareId = unitCareId;

            AddDomainEvent(new PersonnelUpdatedEvent(this));
        }

   

    }
}

