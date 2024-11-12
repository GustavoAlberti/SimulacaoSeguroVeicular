using SimulacaoSeguroVeicular.Domain.Simulacoes.Services;
using SimulacaoSeguroVeicular.Infrastructure.Data;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao.Steps
{
    public class ConsultarHistoricoAcidentesStep(CotacaoRepositorio cotacaoRepositorio, UnitOfWork unitOfWork, FakeConsultarHistoricoAcidentesService fakeConsultarHistoricoAcidentesService) : StepBodyAsync
    {
        public int CotacaoId { get; set; }
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var cotacaoMaybe = await cotacaoRepositorio.Obter(CotacaoId, CancellationToken.None);
            if (cotacaoMaybe.HasNoValue)
                return ExecutionResult.Next();

            var cotacao = cotacaoMaybe.Value;

            var historicoAcidentes = await fakeConsultarHistoricoAcidentesService.ConsultarHistoricoAcidentesAsync(cotacao.Condutor.Cpf);

            cotacao.DefinirNumeroDeAcidentes(historicoAcidentes);

            await unitOfWork.CommitAsync(CancellationToken.None);

            return ExecutionResult.Next();
        }
    }
}
