using Microsoft.AspNetCore.Mvc;
using PIT.Backend.Data; // Asegurate de tener el DbContext definido
using PIT.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace PIT.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitoringController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MonitoringController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterEvent(Event evt)
        {
            _context.Events.Add(evt);
            await _context.SaveChangesAsync();
            return Ok(evt);
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.Events
                .OrderByDescending(e => e.Timestamp)
                .ToListAsync();

            return Ok(events);
        }
    }
}
