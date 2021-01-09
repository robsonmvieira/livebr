using FluentValidation;
using LiveBR.CrossCutting.ValueObject;

namespace LiveBR.Domain.Rules
{
    public class CPfValidator: AbstractValidator<CPF>
    {
        public CPfValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("O CPF não pode ser nulo/vazio")
                .MinimumLength(11)
                .WithMessage("O CPF deve conter 11 digitos");

        }
    }
}