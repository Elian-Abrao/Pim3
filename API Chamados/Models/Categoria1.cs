using System;
using System.Collections.Generic;

namespace API_Chamados.Models;

public partial class Categoria1
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();
}
