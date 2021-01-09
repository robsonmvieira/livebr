using FluentValidation;
using LiveBR.CrossCutting.ValueObject;

namespace LiveBR.Domain.Rules
{
    public class PasswordValidator: AbstractValidator<Password>
    {
        public PasswordValidator()
        {
            RuleFor(p => p.Value)
                .MinimumLength(6)
                .WithMessage("A senha deve conter no mínimo 6 caracteres");
            
        }
    }
}