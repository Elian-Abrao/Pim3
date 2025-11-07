using System;
using System.Collections.Generic;

namespace API_Chamados.Models;

public partial class StatusChamado
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();

    public virtual ICollection<HistoricoChamado> HistoricoChamadoIdStatusAnteriorNavigations { get; set; } = new List<HistoricoChamado>();

    public virtual ICollection<HistoricoChamado> HistoricoChamadoIdStatusNovoNavigations { get; set; } = new List<HistoricoChamado>();
}
