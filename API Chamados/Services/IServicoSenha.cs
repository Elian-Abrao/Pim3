namespace API_Chamados.Services
{
    public interface IServicoSenha
    {
        string GerarHash(string senha);
        bool Verificar(string senha, string hash);
    }
}
