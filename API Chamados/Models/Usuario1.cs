using System;
using System.Collections.Generic;

namespace API_Chamados.Models;

public partial class Usuario1
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SenhaHash { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public bool Ativo { get; set; }

    public DateTime? CriadoEm { get; set; }

    public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();

    public virtual ICollection<HistoricoChamado> HistoricoChamados { get; set; } = new List<HistoricoChamado>();
}
