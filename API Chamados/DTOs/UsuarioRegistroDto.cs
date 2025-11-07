using System.ComponentModel.DataAnnotations;

namespace API_Chamados.DTOs
{
    public class UsuarioRegistroDto
    {
        [Required(ErrorMessage = "O nome é obrigatório."), StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório."), EmailAddress(ErrorMessage = "E-mail inválido."), StringLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória."), StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter ao menos 6 caracteres.")]
        public string Senha { get; set; }

        [StringLength(20, ErrorMessage = "Tipo de usuário inválido." )]
        public string? TipoUsuario { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatorio."), StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 caracteres.")]
        public string CPF { get; set; }
    }

    public class AlterarSenhaDto
    {
        [Required(ErrorMessage = "A senha atual é obrigatória.")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "A nova senha é obrigatória."), StringLength(100, MinimumLength = 6, ErrorMessage = "A nova senha deve ter ao menos 6 caracteres.")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "A confirmação de senha é obrigatória."), Compare("NovaSenha", ErrorMessage = "A confirmação deve ser igual à nova senha.")]
        public string ConfirmacaoNovaSenha { get; set; }
    }
}
