using EstacionamentoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
