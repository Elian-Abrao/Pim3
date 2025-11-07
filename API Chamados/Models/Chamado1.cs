using System;
using System.Collections.Generic;

namespace API_Chamados.Models;

public partial class Chamado1
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int? IdCategoria { get; set; }

    public int IdStatus { get; set; }

    public string? Prioridade { get; set; }

    public DateTime? CriadoEm { get; set; }

    public DateTime? AtualizadoEm { get; set; }

    public virtual ICollection<HistoricoChamado1> HistoricoChamado1s { get; set; } = new List<HistoricoChamado1>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual StatusChamado1 IdStatusNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
