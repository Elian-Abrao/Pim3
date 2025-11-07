using API_Chamados.Data;
using API_Chamados.DTOs;
using API_Chamados.Models;
using API_Chamados.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Chamados.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _contexto;
        private readonly IServicoSenha _servicoSenha;

        public UsuariosController(AppDbContext contexto, IServicoSenha servicoSenha)
        {
            _contexto = contexto;
            _servicoSenha = servicoSenha;
        }

        [HttpPost("registro")]
        [AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioRegistroDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existeEmail = await _contexto.Usuarios.AsNoTracking().AnyAsync(u => u.Email == dto.Email);
            if (existeEmail) return Conflict("E-mail já cadastrado.");

            var existeCpf = await _contexto.Usuarios.AsNoTracking().AnyAsync(u => u.Cpf == dto.CPF);
            if (existeCpf) return Conflict("CPF já cadastrado.");

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = _servicoSenha.GerarHash(dto.Senha),
                Tipo = string.IsNullOrWhiteSpace(dto.TipoUsuario) ? "cliente" : dto.TipoUsuario,
                Cpf = dto.CPF
            };

            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { id = usuario.IdUsuario }, new { usuario.IdUsuario, usuario.Nome, usuario.Email, usuario.Tipo, usuario.Cpf });
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var u = await _contexto.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.IdUsuario == id);
            if (u == null) return NotFound();
            return Ok(new { u.IdUsuario, u.Nome, u.Email, u.Tipo, u.Cpf });
        }

        [HttpPost("{id:int}/alterar-senha")]
        [Authorize]
        [Consumes("application/json")]
        public async Task<IActionResult> AlterarSenha(int id, [FromBody] AlterarSenhaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
            if (usuario == null) return NotFound();

            if (!_servicoSenha.Verificar(dto.SenhaAtual, usuario.SenhaHash))
                return Unauthorized("Senha atual inválida.");

            usuario.SenhaHash = _servicoSenha.GerarHash(dto.NovaSenha);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
