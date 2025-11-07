using System;
using System.Collections.Generic;

namespace API_Chamados.Models;

public partial class HistoricoChamado1
{
    public int Id { get; set; }

    public int IdChamado { get; set; }

    public int? IdUsuario { get; set; }

    public string? Comentario { get; set; }

    public int? IdStatusAnterior { get; set; }

    public int? IdStatusNovo { get; set; }

    public DateTime? RegistradoEm { get; set; }

    public virtual Chamado1 IdChamadoNavigation { get; set; } = null!;

    public virtual StatusChamado1? IdStatusAnteriorNavigation { get; set; }

    public virtual StatusChamado1? IdStatusNovoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
