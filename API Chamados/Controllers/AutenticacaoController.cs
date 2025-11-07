using API_Chamados.DTOs;
using API_Chamados.Models;
using API_Chamados.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API_Chamados.Services;

namespace API_Chamados.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AppDbContext _contexto;
        private readonly ITokenService _tokenService;
        private readonly IServicoSenha _servicoSenha;

        public AutenticacaoController(AppDbContext contexto, ITokenService tokenService, IServicoSenha servicoSenha)
        {
            _contexto = contexto;
            _tokenService = tokenService;
            _servicoSenha = servicoSenha;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Busca por e-mail, nome ou CPF
            var usuario = await _contexto.Usuarios
                .FirstOrDefaultAsync(u => u.Email == loginDto.Login || u.Nome == loginDto.Login || u.Cpf == loginDto.Login);

            if (usuario == null)
            {
                return Unauthorized("Usuário inválido!");
            }

            var senhaOk = _servicoSenha.Verificar(loginDto.Senha, usuario.SenhaHash);
            if (!senhaOk)
            {
                // Aqui se o banco tiver senha em texto puro, atualiza para BCrypt ao logar
                if (usuario.SenhaHash == loginDto.Senha)
                {
                    usuario.SenhaHash = _servicoSenha.GerarHash(loginDto.Senha);
                    await _contexto.SaveChangesAsync();
                }
                else
                {
                    return Unauthorized("Senha incorreta!");
                }
            }

            var token = _tokenService.GerarToken(new Usuario
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                SenhaHash = usuario.SenhaHash,
                Tipo = usuario.Tipo,
                Cpf = usuario.Cpf
            });

            return Ok(new
            {
                mensagem = "Login realizado com sucesso!",
                usuario = new { id = usuario.IdUsuario, nome = usuario.Nome, email = usuario.Email, tipo = usuario.Tipo, cpf = usuario.Cpf },
                token
            });
        }
    }
}
