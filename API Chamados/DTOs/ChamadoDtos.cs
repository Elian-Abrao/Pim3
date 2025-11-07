using System.ComponentModel.DataAnnotations;

namespace API_Chamados.DTOs
{
    public class CriarChamadoDto
    {
        [Required, StringLength(100)]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        public int? PrioridadeId { get; set; }
    }

    public class AtualizarChamadoDto
    {
        [Required, StringLength(100)]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        public int? PrioridadeId { get; set; }
        public string? Status { get; set; }
    }

    public class ChamadoRespostaDto
    {
        public int IdChamado { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public int? PrioridadeId { get; set; }
        public string? Status { get; set; }
        public DateTime? DataAbertura { get; set; }
        public DateTime? DataEncerramento { get; set; }
    }
}
