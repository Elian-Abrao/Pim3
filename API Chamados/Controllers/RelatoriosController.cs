using API_Chamados.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Chamados.Controllers
{
    [ApiController]
    [Route("api/relatorios")]
    [Authorize]
    public class RelatoriosController : ControllerBase
    {
        private readonly AppDbContext _contexto;
        public RelatoriosController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        private static DateTime Unspec(DateTime dt) => DateTime.SpecifyKind(dt, DateTimeKind.Unspecified);

        [HttpGet("diario")]
        public async Task<IActionResult> Diario([FromQuery] DateOnly? data)
        {
            var baseDia = data?.ToDateTime(TimeOnly.MinValue).Date ?? DateTime.Now.Date;
            var dia = Unspec(baseDia);
            var prox = Unspec(baseDia.AddDays(1));
            var total = await _contexto.Chamados.CountAsync(c => c.DataAbertura >= dia && c.DataAbertura < prox);
            return Ok(new { periodo = "diario", data = dia, total });
        }

        [HttpGet("semanal")]
        public async Task<IActionResult> Semanal([FromQuery] DateOnly? inicio)
        {
            var hoje = DateTime.Now.Date;
            var baseIni = inicio?.ToDateTime(TimeOnly.MinValue).Date ?? hoje.AddDays(-(int)hoje.DayOfWeek);
            var semanaIni = Unspec(baseIni);
            var semanaFim = Unspec(baseIni.AddDays(7));
            var total = await _contexto.Chamados.CountAsync(c => c.DataAbertura >= semanaIni && c.DataAbertura < semanaFim);
            return Ok(new { periodo = "semanal", inicio = semanaIni, fim = Unspec(semanaFim.AddDays(-1)), total });
        }

        [HttpGet("mensal")]
        public async Task<IActionResult> Mensal([FromQuery] int? ano, [FromQuery] int? mes)
        {
            var now = DateTime.Now;
            var y = ano ?? now.Year;
            var m = mes ?? now.Month;
            var ini = Unspec(new DateTime(y, m, 1));
            var fim = Unspec(ini.AddMonths(1));
            var total = await _contexto.Chamados.CountAsync(c => c.DataAbertura >= ini && c.DataAbertura < fim);
            return Ok(new { periodo = "mensal", ano = y, mes = m, total });
        }
    }
}
