using System;
using System.Collections.Generic;

namespace API_Chamados.Models;

public partial class Chamado
{
    public int IdChamado { get; set; }

    public int IdUsuario { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int? CategoriaId { get; set; }

    public int? PrioridadeId { get; set; }

    public string? Status { get; set; }

    public DateTime? DataAbertura { get; set; }

    public DateTime? DataEncerramento { get; set; }

    public virtual Categorium? Categoria { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Mensagem> Mensagems { get; set; } = new List<Mensagem>();
}
