using SimulacaoSeguroVeicular.Domain.Simulacoes.Services;
using SimulacaoSeguroVeicular.Dominio.Simulacoes;
using SimulacaoSeguroVeicular.Infrastructure.Data;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao.Steps
{
    public class CalcularValorSeguroStep(CotacaoRepositorio cotacaoRepositorio, UnitOfWork unitOfWork, ValorSeguroService valorSeguroService) : StepBodyAsync
    {
        public int CotacaoId { get; set; }
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            //Calculo do valor do Seguro.
            //Define o ValorSeguroTotal.
            var cotacaoMaybe = await cotacaoRepositorio.Obter(CotacaoId, CancellationToken.None);
            if (cotacaoMaybe.HasNoValue)
                return ExecutionResult.Next();

            var cotacao = cotacaoMaybe.Value;

            decimal valorSeguroTotal = valorSeguroService.CalcularValorSeguroAsync(cotacao);

            // Define o valor do seguro na cotação
            cotacao.CalcularValorSeguroTotal(valorSeguroTotal);

            await unitOfWork.CommitAsync(CancellationToken.None);

            return ExecutionResult.Next();
        }
    }
}
