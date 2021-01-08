using System;

namespace LiveBR.CrossCutting.ValueObject
{
    public class DomainExpection: Exception
    {

        public DomainExpection(string message): base(message)
        {
            
        }
        
        public DomainExpection(string message, Exception innerException): base(message, innerException)
        {
            
        }
    }
}