using FluentValidation;
using Prescription.Application.Features.Prescription.Commands.UpdatePrescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Prescription.Commands.UpdatePrescription
{
    public class UpdatePrescriptionCommand
    {
    }

    public class UpdatePrescriptionCommandValidator : AbstractValidator<UpdatePrescriptionCommand>
    {
        public UpdatePrescriptionCommandValidator()
        {
            /*RuleFor(x => x.Prescription.FirstName).NotEmpty().WithMessage("Prescription.FirstName is required");
            RuleFor(x => x.Prescription.LastName).NotEmpty().WithMessage("Prescription.LastName is required");*/
        }
    }
}