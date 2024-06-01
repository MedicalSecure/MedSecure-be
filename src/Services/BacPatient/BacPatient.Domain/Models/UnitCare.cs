

namespace BacPatient.Domain.Models
{
    public class UnitCare : Aggregate<UnitCareId>
    {
            public Room Room { get; private set; } = default!;

        private readonly List<Personnel?> _personnels = new();
        public IReadOnlyList<Personnel?> Personnels => _personnels.AsReadOnly();
        public string? Title { get; private set; } = default!;
        public string? Description { get; private set; } = default!;
        public string? Type { get; private set; } = default!;
      
        public UnitCare() { }
        public UnitCare(UnitCareId id ,  string? title , string? description , Room room ) {
            Id = id;
            Title = title;
            Description = description; 
            Room = room;
        }
        public static UnitCare Create(
            UnitCareId id,
            string title,
            string description,
            string type , 
            Room room)
        {
            var unitCare = new UnitCare()
            {
                Id = id,
                Title = title,
                Description = description,
                Type = type,
             
            };

            unitCare.AddDomainEvent(new UnitCareCreatedEvent(unitCare));

            return unitCare;
        }
        // lil bac patient 
        public static UnitCare Create(
         UnitCareId id,
         string title,
         string description ,
         Room room)
        {
            var unitCare = new UnitCare()
            {
                Id = id,
                Title = title,
                Description = description,
                Room = room 
            };

            unitCare.AddDomainEvent(new UnitCareCreatedEvent(unitCare));

            return unitCare;
        }
        public static UnitCare Create(
    string title,
    string description)
        {
            var unitCare = new UnitCare()
            {
                Id = UnitCareId.Of(Guid.NewGuid()),
                Title = title,
                Description = description
            };

            unitCare.AddDomainEvent(new UnitCareCreatedEvent(unitCare));

            return unitCare;
        }
        //bac patient
        public void Update(

            string title,
            string description,
            string type)
        {
           
            Title = title;
            Description = description;
            Type = type;

            AddDomainEvent(new UnitCareUpdatedEvent(this));
        }

        public void AddPersonnel(Personnel personnel)
        {
            if (personnel == null)
                throw new ArgumentNullException(nameof(personnel));

            _personnels.Add(personnel);
        }
    }

}
