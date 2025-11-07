using System;
using System.Collections.Generic;

namespace API_Chamados.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public virtual ICollection<Chamado1> Chamado1s { get; set; } = new List<Chamado1>();
}
