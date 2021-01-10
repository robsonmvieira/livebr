using System.ComponentModel.DataAnnotations;

namespace LiveBR.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O {0} não pode estar vazio")]
        [StringLength(100,ErrorMessage = "O {0} tem que conter no mínimo {2} e no máximo {1} caracteres ",  MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "O {0} não pode estar vazio")]
        [EmailAddress(ErrorMessage = "O formato do {0} é inválido ")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O {0} não pode estar vazio")]
        [StringLength(20,ErrorMessage = "O {0} tem que conter no mínimo {1} caracteres ",  MinimumLength = 11)]
        public string Cpf { get; set; }
        
        [Required(ErrorMessage = "O {0} não pode estar vazio")]
        [StringLength(20,ErrorMessage = "O {0} tem que conter no mínimo {2} e no máximo {1} caracteres ",  MinimumLength = 6)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }

    }
}