using SimulacaoSeguroVeicular.Domain.Simulacoes.Services;
using SimulacaoSeguroVeicular.Infrastructure.Data;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao.Steps
{
    public class CalcularNivelRiscoStep(CotacaoRepositorio cotacaoRepositorio, UnitOfWork unitOfWork, CalculaPontuacaoNivelRiscoService calculaPontuacaoNivelRiscoService) : StepBodyAsync
    {
        public int CotacaoId { get; set; }
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {

            //Calculo do nível de risco.
            //O nível de risco é determinado com base em variáveis comuns em avaliações de seguros veiculares,
            //como idade do condutor, histórico de direção e localidade de residência.
            //Cada variável tem uma pontuação que aumenta ou reduz o nível de risco.
            var cotacaoMaybe = await cotacaoRepositorio.Obter(CotacaoId, CancellationToken.None);
            if (cotacaoMaybe.HasNoValue)
                return ExecutionResult.Next();

            var cotacao = cotacaoMaybe.Value;

            int nivelRisco = await calculaPontuacaoNivelRiscoService.CalcularNivelRiscoAsync(cotacao);

            // Define o nível de risco na cotação
            cotacao.DefinirNivelDeRisco(nivelRisco);

            await unitOfWork.CommitAsync(CancellationToken.None);

            return ExecutionResult.Next();
        }
    }
}
