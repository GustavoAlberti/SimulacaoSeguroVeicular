using SimulacaoSeguroVeicular.Infrastructure.Data;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao.Steps
{
    public class AprovarSeguroStep(CotacaoRepositorio cotacaoRepositorio, UnitOfWork unitOfWork) : StepBodyAsync
    {
        public int CotacaoId { get; set; }
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var cotacaoMaybe = await cotacaoRepositorio.Obter(CotacaoId, CancellationToken.None);
            if (cotacaoMaybe.HasNoValue)
                return ExecutionResult.Next();

            Console.WriteLine($"Cotação ID: {CotacaoId} está pronta para aprovação e aguardando confirmação.");

            await unitOfWork.CommitAsync(CancellationToken.None);

            return ExecutionResult.Next();
        }
    }
}
