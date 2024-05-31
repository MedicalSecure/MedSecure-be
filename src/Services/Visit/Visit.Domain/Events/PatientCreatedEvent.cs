﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Domain.Events;


public record PatientCreatedEvent(Patient patient) : IDomainEvent;


