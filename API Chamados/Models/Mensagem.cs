using System;
using System.Collections.Generic;

namespace API_Chamados.Models;

public partial class Mensagem
{
    public int IdMensagem { get; set; }

    public int IdChamado { get; set; }

    public int IdRemetente { get; set; }

    public string Conteudo { get; set; } = null!;

    public DateTime? DataEnvio { get; set; }

    public virtual Chamado IdChamadoNavigation { get; set; } = null!;

    public virtual Usuario IdRemetenteNavigation { get; set; } = null!;
}
