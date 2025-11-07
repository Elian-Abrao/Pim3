using System;
using System.Collections.Generic;

namespace API_Chamados.Models;

public partial class StatusChamado1
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Chamado1> Chamado1s { get; set; } = new List<Chamado1>();

    public virtual ICollection<HistoricoChamado1> HistoricoChamado1IdStatusAnteriorNavigations { get; set; } = new List<HistoricoChamado1>();

    public virtual ICollection<HistoricoChamado1> HistoricoChamado1IdStatusNovoNavigations { get; set; } = new List<HistoricoChamado1>();
}
