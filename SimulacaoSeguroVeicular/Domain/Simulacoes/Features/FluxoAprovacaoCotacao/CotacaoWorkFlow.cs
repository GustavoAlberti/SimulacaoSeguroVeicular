using SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao.Steps;
using WorkflowCore.Interface;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao
{
    public class CotacaoWorkFlow : IWorkflow<CotacaoWorkflowData>
    {
        public string Id => "CotacaoWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<CotacaoWorkflowData> builder)
        {
            builder
                .StartWith<ConsultarValorFipeStep>()
                    .Input(step => step.CotacaoId, data => data.CotacaoId)
                .Then<ConsultarHistoricoAcidentesStep>()
                    .Input(step => step.CotacaoId, data => data.CotacaoId)
                .Then<CalcularNivelRiscoStep>()
                    .Input(step => step.CotacaoId, data => data.CotacaoId)
                .Then<CalcularValorSeguroStep>()
                    .Input(step => step.CotacaoId, data => data.CotacaoId)
                .Then<AprovarSeguroStep>()
                    .Input(step => step.CotacaoId, data => data.CotacaoId)
                .WaitFor("AprovacaoEvent", (data) => data.CotacaoId.ToString())
                .Then<EmitirApoliceStep>()
                    .Input(step => step.CotacaoId, data => data.CotacaoId);

        }
    }
}
