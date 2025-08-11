using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIT.Backend.Data;
using PIT.Backend.Controllers;
using PIT.Shared.Models;
using PIT.Backend.Models;


namespace PIT.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Historial
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistroEmbolsadoDto nuevo)
        {
            var entidad = new RegistroEmbolsado
            {
                LoteId = nuevo.LoteId,
                FechaHora = nuevo.FechaHora,
                Operador = nuevo.Operador,
                Turno = nuevo.Turno,
                Cantidad = nuevo.Cantidad,
                Observaciones = nuevo.Observaciones,
                Estado = nuevo.Estado
            };

            _context.Embolsados.Add(entidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = entidad.Id }, entidad);
        }

        // GET: api/Historial
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FiltroHistoricoDto filtros)
        {
            var query = _context.Embolsados.AsQueryable();

            if (filtros.FechaInicio.HasValue)
                query = query.Where(e => e.FechaHora >= filtros.FechaInicio.Value);

            if (filtros.FechaFin.HasValue)
                query = query.Where(e => e.FechaHora <= filtros.FechaFin.Value);

            if (!string.IsNullOrEmpty(filtros.Turno))
                query = query.Where(e => e.Turno == filtros.Turno);

            if (!string.IsNullOrEmpty(filtros.Operador))
                query = query.Where(e => e.Operador.Contains(filtros.Operador));

            var total = await query.CountAsync();
            var registros = await query
                .OrderByDescending(e => e.FechaHora)
                .Skip((filtros.Pagina - 1) * filtros.TamanoPagina)
                .Take(filtros.TamanoPagina)
                .ToListAsync();

            return Ok(new { total, pagina = filtros.Pagina, registros });
        }

        // GET: api/Historial/test
        [HttpGet("test")]
        public IActionResult GetTest()
        {
            var registros = new List<RegistroEmbolsadoDto>
            {
                new() { LoteId = "L001", FechaHora = DateTime.Now, Operador = "Fernando", Turno = "Mañana", Cantidad = 50, Observaciones = "Prueba", Estado = "OK" },
                new() { LoteId = "L002", FechaHora = DateTime.Now.AddMinutes(-30), Operador = "Ana", Turno = "Tarde", Cantidad = 40, Observaciones = "Simulado", Estado = "Pendiente" }
            };

            var respuesta = new RespuestaHistorial
            {
                Total = registros.Count,
                Pagina = 1,
                Registros = registros
            };

            return Ok(respuesta);
        }
    }
}
