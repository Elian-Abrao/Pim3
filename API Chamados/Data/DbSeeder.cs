using API_Chamados.Models;
using API_Chamados.Services;
using Microsoft.EntityFrameworkCore;

namespace API_Chamados.Data
{
    public static class DbSeeder
    {
        public static async Task SeedInicialAsync(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contexto = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var servicoSenha = scope.ServiceProvider.GetRequiredService<IServicoSenha>();
            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            // Lê configs do seeder (podem vir de appsettings ou variáveis de ambiente)
            var enabled = config.GetValue("SeedAdmin:Enabled", true);
            if (!enabled) return;

            var email = config.GetValue<string>("SeedAdmin:Email") ?? "admin@chamados.local";
            var nome = config.GetValue<string>("SeedAdmin:Nome") ?? "Administrador";
            var senha = config.GetValue<string>("SeedAdmin:Senha") ?? "Admin@123";
            var tipo = config.GetValue<string>("SeedAdmin:Tipo") ?? "admin";

            try
            {
                await contexto.Database.OpenConnectionAsync();
                await contexto.Database.CloseConnectionAsync();
            }
            catch
            {
                return;
            }

            // Cria admin se não existir por e-mail (independente de já haver outros usuários)
            var existeAdmin = await contexto.Usuarios.AsNoTracking().AnyAsync(u => u.Email == email);
            if (!existeAdmin)
            {
                var admin = new Usuario
                {
                    Nome = nome,
                    Email = email,
                    SenhaHash = servicoSenha.GerarHash(senha),
                    Tipo = tipo
                };
                contexto.Usuarios.Add(admin);
                await contexto.SaveChangesAsync();
            }
        }
    }
}
