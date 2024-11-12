using CSharpFunctionalExtensions;
using SimulacaoSeguroVeicular.Infrastructure.Data;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Handlers
{
    public class ReprovarCotacaoHandler(CotacaoRepositorio cotacaoRepositorio, UnitOfWork unitOfWork)
    {
        public async Task<Result> ReprovarCotacao(int cotacaoId, CancellationToken cancellationToken)
        {
            var cotacaoMaybe = await cotacaoRepositorio.Obter(cotacaoId, cancellationToken);
            if (cotacaoMaybe.HasNoValue)
                return Result.Failure("Cotação não encontrada");

            var cotacao = cotacaoMaybe.Value;
            cotacao.Reprovar();

            await unitOfWork.CommitAsync(cancellationToken);

            return Result.Success();
        }

    }
}
