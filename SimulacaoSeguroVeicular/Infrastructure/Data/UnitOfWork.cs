namespace SimulacaoSeguroVeicular.Infrastructure.Data
{
    public sealed class UnitOfWork(CotacaoDbContext context)
    {
        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
