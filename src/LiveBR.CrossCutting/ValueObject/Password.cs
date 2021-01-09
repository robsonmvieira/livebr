using FluentValidation;

namespace LiveBR.CrossCutting.ValueObject
{
    public class Password
    {
        public string Value { get; private set; }

        protected Password() {}

        public Password(string value)
        {
            if (!IsValidPassword(value)) throw new DomainExpection("O valor da senha não pode estar ser vazio");
            Value = value;
        }

        private static bool IsValidPassword(string password)
        {
            var isValid = password != null;
            return isValid;

        }
    }
    
    
    
    
}