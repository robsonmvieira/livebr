using FluentValidation;
using LiveBR.Domain.Entities;

namespace LiveBR.Domain.Rules
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")
                .MinimumLength(3)
                .WithMessage("O nome precisa ter no mínimo 3 caracteres");
            RuleFor(x => x.Cpf).SetValidator(new CPfValidator());
            RuleFor(x => x.Email).SetValidator(new EmailValidator());
            RuleFor(x => x.Password).SetValidator(new PasswordValidator());
        }
    }
}