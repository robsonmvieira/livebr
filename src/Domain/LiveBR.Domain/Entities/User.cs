using FluentValidation;
using LiveBR.CrossCutting.ValueObject;
using LiveBR.Domain.Rules;

namespace LiveBR.Domain.Entities
{
    public class User: Entity
    {
        public string Name { get;  private set; }
        public Email Email { get; private set; }
        public CPF Cpf { get; private set; }
        public Password Password { get; private set; }

        public User() {}

        public User(string name, string email, string cpf, string password)
        {
            Name = name;
            Email = new Email(email);
            Cpf = new CPF(cpf);
            Password = new Password(password);
        }

        public void UpdateEmail(string email)
        {
            Email = new Email(email);
        }

        public void ChangePassword(string newPassword)
        {
            Password = new Password(newPassword);
        }

        public void IsValidUser() => new UserValidator().ValidateAndThrow(this);
        
    }
}