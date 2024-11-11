using SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao.Steps;

namespace SimulacaoSeguroVeicular.Extensions
{
    public static class WorkflowExtensions
    {
        public static IServiceCollection AddWorkflowSteps(this IServiceCollection services)
        {
            services.AddTransient<ConsultarValorFipeStep>();
            services.AddTransient<ConsultarHistoricoAcidentesStep>();
            services.AddTransient<CalcularNivelRiscoStep>();
            services.AddTransient<CalcularValorSeguroStep>();
            services.AddTransient<AprovarSeguroStep>();
            services.AddTransient<EmitirApoliceStep>();

            return services;
        }
    }
}
