using BuildingBlocks.CQRS;
using FluentValidation;
using Registration.Application.Dtos;

namespace Registration.Application.Register.Commands.UpdateRegister
{
    public record UpdateRegisterCommand(RegisterDto Register): ICommand<UpdateRegisterResult>;
         public record UpdateRegisterResult(bool IsSuccess);

    public class UpdateRegisterCommandValidator : AbstractValidator<UpdateRegisterCommand>
    {
        public UpdateRegisterCommandValidator()
        {
            RuleFor(x => x.Register.Id).NotEmpty().WithMessage("RegisterId is required");
        }
    }
    
}
