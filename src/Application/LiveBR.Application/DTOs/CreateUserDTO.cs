using System.ComponentModel.DataAnnotations;

namespace LiveBR.Application.ViewModels
{
    public class CreateUserDto
    {
        public string Name { get;  set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
    }
}