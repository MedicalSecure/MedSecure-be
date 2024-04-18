﻿
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

        public List<string> Hours { get; private set; } = default!;
        public static Posology Create(
            PoslogyId Id ,
            DateTime StartDate,
            DateTime EndDate,
            int QuantityBE,
            int QuantityAE,
            bool IsPermanent,
            List<string> Hours
        )
        {
            var posology = new Posology()
            {
                Id = Id ,
                StartDate = StartDate,
                EndDate = EndDate,
                QuantityBE = QuantityBE,
                QuantityAE = QuantityAE,
                IsPermanent = IsPermanent,
                Hours = Hours
            };

            return posology;
        }

    }
}
