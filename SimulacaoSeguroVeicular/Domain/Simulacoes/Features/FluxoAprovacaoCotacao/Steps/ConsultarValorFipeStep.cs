using SimulacaoSeguroVeicular.Domain.Simulacoes.Services;
using SimulacaoSeguroVeicular.Infrastructure.Data;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao.Steps
{
    public class ConsultarValorFipeStep(CotacaoRepositorio cotacaoRepositorio, UnitOfWork unitOfWork, FakeTabelaFipeService fakeTabelaFipeService) : StepBodyAsync
    {
        public int CotacaoId { get; set; }
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var cotacaoMaybe = await cotacaoRepositorio.Obter(CotacaoId, CancellationToken.None);
            if (cotacaoMaybe.HasNoValue)
                return ExecutionResult.Next();

            var cotacao = cotacaoMaybe.Value;

            var valorFipe = await fakeTabelaFipeService.ConsultarValorAsync(cotacao.Veiculo.Marca, cotacao.Veiculo.Modelo, cotacao.Veiculo.Ano);
            cotacao.DefinirValorFipe(valorFipe);

            await unitOfWork.CommitAsync(CancellationToken.None);
            
            return ExecutionResult.Next();
        }
    }
}
