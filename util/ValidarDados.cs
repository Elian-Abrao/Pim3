using System;
using System.Windows.Forms;
using Npgsql;
using System.Security.Cryptography;
using System.Text;

namespace Pim3Semestre.util
{
    internal class ValidarDados
    {
        public static bool ValidarEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        public static bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "").Trim();
            return cpf.Length == 11;
        }

        public static string GerarHash(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
