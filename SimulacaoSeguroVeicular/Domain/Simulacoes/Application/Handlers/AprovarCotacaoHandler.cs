using CSharpFunctionalExtensions;
using SimulacaoSeguroVeicular.Infrastructure.Data;
using System.Threading;
using WorkflowCore.Interface;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Handlers
{
    public class AprovarCotacaoHandler(IWorkflowHost workflowHost, CotacaoRepositorio cotacaoRepositorio, UnitOfWork unitOfWork)
    {
        public async Task<Result> AprovarCotacao(int cotacaoId, CancellationToken cancellationToken)
        {
            var cotacaoMaybe = await cotacaoRepositorio.Obter(cotacaoId, cancellationToken);
            if (cotacaoMaybe.HasNoValue)
                return Result.Failure("Cotação não encontrada");

            var cotacao = cotacaoMaybe.Value;
            cotacao.Aprovar();

            await unitOfWork.CommitAsync(cancellationToken);

            workflowHost.PublishEvent("AprovacaoEvent", cotacaoId.ToString(), null);

            return Result.Success();
        }

    }
}
