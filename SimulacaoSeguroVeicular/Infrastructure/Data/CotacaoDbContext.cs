using Microsoft.EntityFrameworkCore;
using SimulacaoSeguroVeicular.Domain.Simulacoes;
using SimulacaoSeguroVeicular.Dominio.Simulacoes;
using SimulacaoSeguroVeicular.Infrastructure.Data.Mapping;

namespace SimulacaoSeguroVeicular.Infrastructure.Data
{
    public class CotacaoDbContext : DbContext
    {
        public CotacaoDbContext(DbContextOptions<CotacaoDbContext> options) : base(options) { }

        public DbSet<CotacaoSeguroVeicular> Cotacoes { get; set; }
        public DbSet<Apolice> Apolices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CotacaoSeguroVeicularMap());
            modelBuilder.ApplyConfiguration(new ApoliceSeguroVeicularMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
