﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Domain.Events
{

    public record PersonnelUpdatedEvent(Personnel personnel) : IDomainEvent;
}