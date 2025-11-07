using API_Chamados.Data;
using API_Chamados.DTOs;
using API_Chamados.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Chamados.Controllers
{
    [ApiController]
    [Route("api/chamados")]
    [Authorize]
    public class ChamadosController : ControllerBase
    {
        private readonly AppDbContext _contexto;
        public ChamadosController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoRespostaDto>>> Listar()
        {
            var itens = await _contexto.Chamados.AsNoTracking()
                .Select(c => new ChamadoRespostaDto
                {
                    IdChamado = c.IdChamado,
                    IdUsuario = c.IdUsuario,
                    Titulo = c.Titulo,
                    Descricao = c.Descricao,
                    CategoriaId = c.CategoriaId ?? 0,
                    PrioridadeId = c.PrioridadeId,
                    Status = c.Status,
                    DataAbertura = c.DataAbertura,
                    DataEncerramento = c.DataEncerramento
                })
                .ToListAsync();
            return Ok(itens);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ChamadoRespostaDto>> BuscarPorId(int id)
        {
            var c = await _contexto.Chamados.AsNoTracking().FirstOrDefaultAsync(x => x.IdChamado == id);
            if (c == null) return NotFound();

            return Ok(new ChamadoRespostaDto
            {
                IdChamado = c.IdChamado,
                IdUsuario = c.IdUsuario,
                Titulo = c.Titulo,
                Descricao = c.Descricao,
                CategoriaId = c.CategoriaId ?? 0,
                PrioridadeId = c.PrioridadeId,
                Status = c.Status,
                DataAbertura = c.DataAbertura,
                DataEncerramento = c.DataEncerramento
            });
        }

        [HttpPost]
        public async Task<ActionResult<ChamadoRespostaDto>> Criar([FromBody] CriarChamadoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var agora = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            var novo = new Chamado
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                IdUsuario = dto.IdUsuario,
                CategoriaId = dto.CategoriaId, // pode ser null
                PrioridadeId = dto.PrioridadeId,
                Status = "aberto",
                DataAbertura = agora
            };

            _contexto.Chamados.Add(novo);
            await _contexto.SaveChangesAsync();

            var resp = new ChamadoRespostaDto
            {
                IdChamado = novo.IdChamado,
                IdUsuario = novo.IdUsuario,
                Titulo = novo.Titulo,
                Descricao = novo.Descricao,
                CategoriaId = novo.CategoriaId ?? 0,
                PrioridadeId = novo.PrioridadeId,
                Status = novo.Status,
                DataAbertura = novo.DataAbertura,
                DataEncerramento = novo.DataEncerramento
            };

            return CreatedAtAction(nameof(BuscarPorId), new { id = resp.IdChamado }, resp);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] AtualizarChamadoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entidade = await _contexto.Chamados.FirstOrDefaultAsync(x => x.IdChamado == id);
            if (entidade == null) return NotFound();

            entidade.Titulo = dto.Titulo;
            entidade.Descricao = dto.Descricao;
            entidade.CategoriaId = dto.CategoriaId; // pode ser null
            entidade.PrioridadeId = dto.PrioridadeId;
            entidade.Status = dto.Status ?? entidade.Status;

            if (string.Equals(entidade.Status, "encerrado", StringComparison.OrdinalIgnoreCase) && entidade.DataEncerramento == null)
            {
                entidade.DataEncerramento = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            }

            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var entidade = await _contexto.Chamados.FirstOrDefaultAsync(x => x.IdChamado == id);
            if (entidade == null) return NotFound();

            _contexto.Chamados.Remove(entidade);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
