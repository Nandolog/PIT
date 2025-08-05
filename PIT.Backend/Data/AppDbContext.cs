using Microsoft.EntityFrameworkCore;
using PIT.Backend.Models;
using System.Collections.Generic;
// DbContext principal del sistema.
// Incluye el DbSet<Event> para el módulo de monitoreo

namespace PIT.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
