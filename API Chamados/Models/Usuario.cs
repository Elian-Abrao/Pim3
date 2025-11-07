using System;
using System.Collections.Generic;

namespace API_Chamados.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SenhaHash { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();

    public virtual ICollection<Mensagem> Mensagems { get; set; } = new List<Mensagem>();
}
