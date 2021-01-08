using System.ComponentModel.DataAnnotations;

namespace LiveBR.Application.ViewModels
{
    public class CreateUserDTO
    {
        public string Name { get;  set; }
        public string Email { get; set; }
        public string CPF { get; set; }
    }
}