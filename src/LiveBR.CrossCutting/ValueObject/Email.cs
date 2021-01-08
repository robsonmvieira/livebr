using System.Text.RegularExpressions;

namespace LiveBR.CrossCutting.ValueObject
{
    public class Email
    {
        public string Value { get; private set; }

        protected Email() { }
        public Email(string value)
        {
            if (value == null) throw new DomainExpection("O email não pode ser vazio");

            if (!EmailIsValid(value)) throw new DomainExpection("O email está em um formato inválido");
            
            Value = value;
        }

        #region Private Methods

        private static bool EmailIsValid(string emailAddress)
        {
            
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                       + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                       + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
		
            var pattern = new Regex(validEmailPattern, RegexOptions.IgnoreCase);
            bool isValid = pattern.IsMatch(emailAddress);

            return isValid;
        }
        
        #endregion
  
    }
    
    
}