using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Prescription.Commands.CreatePrescription
{
    public record CreatePrescriptionCommand(PrescriptionDto Prescription) : ICommand<CreatePrescriptionResult>;

    public record CreatePrescriptionResult(Guid Id);

    public class CreatePrescriptionCommandValidator : AbstractValidator<CreatePrescriptionCommand>
    {
        public CreatePrescriptionCommandValidator()
        {
            RuleFor(x => x.Prescription.DoctorId).NotEmpty().WithMessage("Prescription.DoctorId is required");
            RuleFor(x => x.Prescription.PatientId).NotEmpty().WithMessage("Prescription.PatientId is required");

        }
    }
}