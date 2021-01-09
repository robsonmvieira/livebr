using FluentValidation;
using LiveBR.CrossCutting.ValueObject;

namespace LiveBR.Domain.Rules
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(e => e.Value)
                .NotEmpty()
                .WithMessage("O Email não pode ser vazio")
                .EmailAddress()
                .WithMessage("O Email informado está em um formato inválido");

        }
    }
}