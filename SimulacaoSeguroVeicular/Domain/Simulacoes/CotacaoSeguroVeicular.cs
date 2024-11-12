using CSharpFunctionalExtensions;
using SimulacaoSeguroVeicular.Domain.Simulacoes;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Value_Objects;

namespace SimulacaoSeguroVeicular.Dominio.Simulacoes
{
    public sealed class CotacaoSeguroVeicular : Entity<int>
    {
        public Veiculo Veiculo { get; }
        public Pessoa Proprietario { get; }
        public Pessoa Condutor { get; }
        public TipoCobertura CoberturaSelecionada { get; }
        public decimal ValorSeguroTotal { get; private set; } // calculado no workflow
        public DateTime? DataAprovacao { get; private set; }
        public bool Aprovado => DataAprovacao.HasValue;
        public decimal? ValorMercadoFipe { get; private set; } // calculado no workflow
        public int? NivelDeRisco { get; private set; } // calculado no workflow
        public int? NumeroDeAcidentes { get; private set; } // calculado no workflow

        public SeguroVeicularStatus Status { get; private set; } = SeguroVeicularStatus.Pendente; //deve sempre abrir como pendente

        private CotacaoSeguroVeicular() {}

        private CotacaoSeguroVeicular(
            Veiculo veiculo,
            Pessoa proprietario,
            Pessoa condutor,
            TipoCobertura coberturaSelecionada)
        {
            Veiculo = veiculo;
            Proprietario = proprietario;
            Condutor = condutor;
            CoberturaSelecionada = coberturaSelecionada;
        }

        public static Result<CotacaoSeguroVeicular> Criar(
        Veiculo veiculo,
        Pessoa proprietario,
        Pessoa condutor,
        TipoCobertura coberturaSelecionada)
        {
            var simulacao = new CotacaoSeguroVeicular(
                veiculo,
                proprietario,
                condutor,
                coberturaSelecionada);

            return Result.Success(simulacao);
        }

        public void DefinirValorFipe(decimal valorFipe)
        {
            ValorMercadoFipe = valorFipe;
        }

        public void DefinirNivelDeRisco(int nivelRisco)
        {
            NivelDeRisco = nivelRisco;
        }
        public void DefinirNumeroDeAcidentes(int numeroDeAcidentes)
        {
            NumeroDeAcidentes = numeroDeAcidentes;
        }

        public void CalcularValorSeguroTotal(decimal valorBase)
        {
            ValorSeguroTotal = valorBase;
        }

        public void Aprovar()
        {
            DataAprovacao = DateTime.UtcNow;
            Status = SeguroVeicularStatus.Aprovado;
        }

        public void Reprovar()
        {
            DataAprovacao = null;
            Status = SeguroVeicularStatus.Rejeitado;
        }

    }

    public enum SeguroVeicularStatus
    {
        Pendente,
        Aprovado,
        Rejeitado
    }

    public enum TipoCobertura
    {
        RouboFurto,
        Colisao,
        Terceiros,
        ProtecaoResidencial
    }

    public record Veiculo(string Marca, string Modelo, int Ano);
}
