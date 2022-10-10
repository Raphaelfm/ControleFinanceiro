using ControleDeFinancas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeFinancas.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ContasPagar> contasPagar { get; set; }
        public DbSet<ContasReceber> contasReceber { get; set; }
    }
}
