using Microsoft.EntityFrameworkCore;
using SimulacaoSeguroVeicular.Dominio.Simulacoes;
using SimulacaoSeguroVeicular.Infrastructure.Data.Mapping;

namespace SimulacaoSeguroVeicular.Infrastructure.Data
{
    public class CotacaoDbContext : DbContext
    {
        public CotacaoDbContext(DbContextOptions<CotacaoDbContext> options) : base(options) { }

        public DbSet<CotacaoSeguroVeicular> Cotacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CotacaoSeguroVeicularMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
