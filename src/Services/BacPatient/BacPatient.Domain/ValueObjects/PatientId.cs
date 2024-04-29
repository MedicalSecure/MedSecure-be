﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Domain.ValueObjects
{
    public record  PatientId
    {
        public Guid Value { get; }
        private PatientId() { } 
        private PatientId(Guid value) => Value = value;

        public static PatientId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("PatientId cannot be empty!");
            }
            return new PatientId(value);
        }
    }
}