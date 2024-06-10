using Prescription.Domain.ValueObjects;

namespace Medication.Application.Validations.Commands.UpdateValidation;

public record UpdateValidationCommand(ValidationDto Validation) : ICommand<UpdateValidationResult>;
public record UpdateValidationResult(ValidationDto Validation);
