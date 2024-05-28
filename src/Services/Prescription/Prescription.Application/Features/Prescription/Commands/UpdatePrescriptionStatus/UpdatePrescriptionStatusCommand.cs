using FluentValidation;
using Prescription.Application.Features.Prescription.Commands.UpdatePrescriptionStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Prescription.Commands.UpdatePrescriptionStatus
{
    public record UpdatePrescriptionStatusCommand(PrescriptionDTO Prescription) : ICommand<UpdatePrescriptionStatusResult>;

    public record UpdatePrescriptionStatusResult(Guid Id);

    public class UpdatePrescriptionStatusCommandValidator : AbstractValidator<UpdatePrescriptionStatusCommand>
    {
        public UpdatePrescriptionStatusCommandValidator()
        {
            /*RuleFor(x => x.Prescription.FirstName).NotEmpty().WithMessage("Prescription.FirstName is required");
            RuleFor(x => x.Prescription.LastName).NotEmpty().WithMessage("Prescription.LastName is required");*/
        }
    }
}