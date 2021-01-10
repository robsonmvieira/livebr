using System.ComponentModel.DataAnnotations;

namespace LiveBR.API.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "O {0} não pode estar vazio")]
        [EmailAddress(ErrorMessage = "O formato do {0} é inválido ")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O {0} não pode estar vazio")]
        [StringLength(20,ErrorMessage = "O {0} tem que conter no mínimo {2} e no máximo {1} caracteres ",  MinimumLength = 6)]
        public string Password { get; set; }
    }
}