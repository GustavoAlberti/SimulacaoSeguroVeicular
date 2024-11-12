using SimulacaoSeguroVeicular.Infrastructure.Data;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao.Steps
{
    public class EmitirApoliceStep(CotacaoRepositorio cotacaoRepositorio, UnitOfWork unitOfWork) : StepBodyAsync
    {
        public int CotacaoId { get; set; }
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var cotacaoMaybe = await cotacaoRepositorio.Obter(CotacaoId, CancellationToken.None);

            if (cotacaoMaybe.HasNoValue)
                return ExecutionResult.Next();

            var cotacao = cotacaoMaybe.Value;

            var apolice = new Apolice
            {
                CotacaoId = cotacao.Id,
                MarcaVeiculo = cotacao.Veiculo.Marca,
                ModeloVeiculo = cotacao.Veiculo.Modelo,
                AnoVeiculo = cotacao.Veiculo.Ano,
                NomeProprietario = cotacao.Proprietario.Nome,
                CpfProprietario = cotacao.Proprietario.Cpf,
                NomeCondutor = cotacao.Condutor.Nome,
                CpfCondutor = cotacao.Condutor.Cpf,
                TipoCobertura = cotacao.CoberturaSelecionada.ToString(),
                ValorSeguroTotal = cotacao.ValorSeguroTotal,
                DataEmissao = DateTime.UtcNow,
                DataVigencia = DateTime.UtcNow.AddYears(1),
            };

            await cotacaoRepositorio.AdicionarApolice(apolice, CancellationToken.None);
            await unitOfWork.CommitAsync(CancellationToken.None);

            Console.WriteLine($"Apólice emitida com sucesso para CotacaoId: {CotacaoId}");
            return ExecutionResult.Next();
        }
    }
}
