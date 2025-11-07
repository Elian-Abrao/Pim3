namespace API_Chamados.Services
{
    public class ServicoSenhaBcrypt : IServicoSenha
    {
        // Custo padrão 10 é ok. Pode aumentar conforme necessidade.
        private const int WorkFactor = 10;

        public string GerarHash(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException("Senha vazia", nameof(senha));
            return BCrypt.Net.BCrypt.HashPassword(senha, workFactor: WorkFactor);
        }

        public bool Verificar(string senha, string hash)
        {
            if (string.IsNullOrWhiteSpace(hash)) return false;
            try
            {
                return BCrypt.Net.BCrypt.Verify(senha, hash);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                // Hash não está em formato BCrypt válido
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
