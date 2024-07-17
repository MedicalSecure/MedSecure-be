using Prescription.Domain.ValueObjects;
using System.Reflection.Emit;

namespace Prescription.Domain.Entities
{
    public class DietForPrescription : Entity<DietForPrescriptionId>
    {
        private readonly List<Guid> _dietsId = new();
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public List<Guid> DietsId => _dietsId;
        private DietForPrescription()
        { } 

        private DietForPrescription(DietForPrescriptionId id, List<Guid> dietsId, DateOnly startDate, DateOnly endDate)
        {
            Validator.isNotNull(StartDate, nameof(StartDate));
            Validator.isNotNull(EndDate, nameof(EndDate));
            Validator.isNotNull(id, nameof(DietForPrescriptionId));
            _dietsId = dietsId;
            StartDate = startDate;
            EndDate = endDate;
            Id = id;
        }

        public void AddDiet(Guid dietId)
        {
            if (_dietsId.Contains(dietId) == false)
                _dietsId.Add(dietId);
        }

        public void AddDiet(List<Guid> dietIds)
        {
            foreach (var dietId in dietIds)
            {
                if (_dietsId.Contains(dietId) == false)
                    _dietsId.Add(dietId);
            }
        }

        public static DietForPrescription Create(List<Guid> dietsId, DateOnly StartDate, DateOnly EndDate)
        {
            var id = DietForPrescriptionId.Of(Guid.NewGuid());
            return new DietForPrescription(id, dietsId, StartDate, EndDate);
        }

        public static DietForPrescription Create(DietForPrescriptionId id, List<Guid> dietsId, DateOnly StartDate, DateOnly EndDate)
        {
            return new DietForPrescription(id, dietsId, StartDate, EndDate);
        }
    }
}