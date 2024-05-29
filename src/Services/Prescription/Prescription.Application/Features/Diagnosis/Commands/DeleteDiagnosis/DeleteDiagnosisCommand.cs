using FluentValidation;
using Prescription.Application.Features.Diagnosis.Commands.CreateDiagnosis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Diagnosis.Commands.DeleteDiagnosis
{
    public record DeleteDiagnosisCommand(DiagnosisDTO Diagnosis) : ICommand<DeleteDiagnosisResult>;

    public record DeleteDiagnosisResult(Guid Id);

    public class DeleteDiagnosisCommandValidator : AbstractValidator<DeleteDiagnosisCommand>
    {
        public DeleteDiagnosisCommandValidator()
        {
            RuleFor(x => x.Diagnosis.Id).NotEqual(Guid.Empty).When(x => string.IsNullOrEmpty(x.Diagnosis.Code)).WithMessage("At least either Diagnosis Id or Code must be provided");
            RuleFor(x => x.Diagnosis.Code).NotEmpty().When(x => x.Diagnosis.Id == Guid.Empty).WithMessage("At least either Diagnosis Id or Code must be provided");
        }
    }
}