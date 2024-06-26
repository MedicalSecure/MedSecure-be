﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Application.Patients.Commands.CreatePatient;
public record CreatePatientCommand(PatientDto Patient) : ICommand<CreatePatientResult>;

public record CreatePatientResult(Guid Id);

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(x => x.Patient.FirstName).NotEmpty().WithMessage("Patient.FirstName is required");
        RuleFor(x => x.Patient.LastName).NotEmpty().WithMessage("Patient.LastName is required");
    }
}

