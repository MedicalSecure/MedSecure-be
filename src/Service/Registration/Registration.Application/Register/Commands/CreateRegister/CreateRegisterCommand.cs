using BuildingBlocks.CQRS;
using FluentValidation;
using Registration.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Register.Commands.CreateRegister
{
    public record CreateRegisterCommand(RegisterDto Register) : ICommand<CreateRegisterResult>;
    public record CreateRegisterResult(Guid Id);
    public class CreateRegisterValidatior : AbstractValidator<CreateRegisterCommand>
    {
        public CreateRegisterValidatior()
        {
            RuleFor(x => x.Register.personalHistory).NotEmpty();
        }
    }
}
