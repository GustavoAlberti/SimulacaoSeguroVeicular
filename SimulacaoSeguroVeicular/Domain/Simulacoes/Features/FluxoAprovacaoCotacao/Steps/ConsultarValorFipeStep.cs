using SimulacaoSeguroVeicular.Infrastructure.Data;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao.Steps
{
    public class ConsultarValorFipeStep(CotacaoRepositorio cotacaoRepository, UnitOfWork unitOfWork) : StepBodyAsync
    {
        public int CotacaoId { get; set; }
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
