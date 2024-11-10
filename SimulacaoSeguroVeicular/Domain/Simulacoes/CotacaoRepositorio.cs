using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using SimulacaoSeguroVeicular.Dominio.Simulacoes;
using SimulacaoSeguroVeicular.Infrastructure.Data;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes
{
    public sealed class CotacaoRepositorio(CotacaoDbContext dbContext)
    {
        public async Task Adicionar(CotacaoSeguroVeicular cotacaoSeguro, CancellationToken cancellationToken)
        {
            await dbContext.Cotacoes.AddAsync(cotacaoSeguro, cancellationToken);
        }

        public async Task<Maybe<CotacaoSeguroVeicular>> Obter(int id, CancellationToken cancellationToken)
        {
            return await dbContext
                .Cotacoes
                .FirstAsync(c => c.Id == id, cancellationToken);
        }
    }
}
