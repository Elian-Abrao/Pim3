using System.ComponentModel.DataAnnotations;

namespace API_Chamados.DTOs
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "o login é obrigatório!")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O login deve conter de 3 a 150 caracteres.")]
        public string Login { get; set; }  
        
        [Required(ErrorMessage = "A senha é obrigatória!")]
        public string Senha { get; set; }
    }
}
