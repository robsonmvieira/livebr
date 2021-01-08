using LiveBR.CrossCutting.ValueObject;

namespace LiveBR.Domain.Entities
{
    public class User: Entity
    {
        public string Name { get;  private set; }
        public Email Email { get; private set; }
        public CPF Cpf { get; private set; }


        public User(string name, string email, string cpf)
        {
            Name = name;
            Email = new Email(email);
            Cpf = new CPF(cpf);
        }

        public void UpdateEmail(string email)
        {
            Email = new Email(email);
        }
        
        
    }
}