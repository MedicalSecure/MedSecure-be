
using BacPatient.Domain.ValueObjects;

namespace BacPatient.Domain.Models
{
    public class Posology : Aggregate<PoslogyId>
    {
        public DateTime StartDate { get; private set; } = default!;
        public DateTime EndDate { get; private set; } = default!;

        public int QuantityBE { get; private set; } = default!;
        public int QuantityAE { get; private set; } = default!;

        public bool IsPermanent { get; private set; } = default!;

        public List<int> Hours { get; private set; } = default!;
        public static Posology Create(
            PoslogyId Id ,
            DateTime StartDate,
            DateTime EndDate,
            int quantityBE,
            int quantityAE,
            bool IsPermanent,
            List<int> Hours
        )
        {
            var posology = new Posology()
            {
                Id = Id ,
                StartDate = StartDate,
                EndDate = EndDate,
                QuantityBE = quantityBE,
                QuantityAE = quantityAE,
                IsPermanent = IsPermanent,
                Hours = Hours
            };

            return posology;
        }

    }
}
