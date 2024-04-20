using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Diagnosis.Commands.CreateDiagnosis
{
    public record CreateDiagnosisCommand(DiagnosisDto Diagnosis) : ICommand<CreateDiagnosisResult>;

    public record CreateDiagnosisResult(Guid Id);

    public class CreateDiagnosisCommandValidator : AbstractValidator<CreateDiagnosisCommand>
    {
        public CreateDiagnosisCommandValidator()
        {
            /*RuleFor(x => x.Diagnosis.FirstName).NotEmpty().WithMessage("Diagnosis.FirstName is required");
            RuleFor(x => x.Diagnosis.LastName).NotEmpty().WithMessage("Diagnosis.LastName is required");*/
        }
    }
}