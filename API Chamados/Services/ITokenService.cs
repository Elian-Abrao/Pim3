using API_Chamados.Models;

namespace API_Chamados.Services
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}
