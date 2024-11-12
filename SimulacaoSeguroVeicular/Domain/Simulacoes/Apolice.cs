using CSharpFunctionalExtensions;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes
{
    public sealed class Apolice : Entity<int>
    {
        public int CotacaoId { get; set; }
        public string MarcaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public int AnoVeiculo { get; set; }
        public string NomeProprietario { get; set; }
        public string CpfProprietario { get; set; }
        public string NomeCondutor { get; set; }
        public string CpfCondutor { get; set; }
        public string TipoCobertura { get; set; }
        public decimal ValorSeguroTotal { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVigencia { get; set; }
    }
}
