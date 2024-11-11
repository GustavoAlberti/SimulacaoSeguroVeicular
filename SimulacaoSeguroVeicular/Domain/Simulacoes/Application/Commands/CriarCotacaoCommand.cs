using SimulacaoSeguroVeicular.Domain.Simulacoes.Value_Objects;
using SimulacaoSeguroVeicular.Dominio.Simulacoes;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Commands
{
    public class CriarCotacaoCommand
    {
        public string MarcaVeiculo { get; }
        public string ModeloVeiculo { get; }
        public int AnoVeiculo { get; }

        public string CpfProprietario { get; }
        public string NomeProprietario { get; }
        public Endereco EnderecoProprietario { get; }
        public DateTime DataNascimentoProprietario { get; }

        public string CpfCondutor { get; }
        public string NomeCondutor { get; }
        public Endereco EnderecoCondutor { get; }
        public DateTime DataNascimentoCondutor { get; }

        public TipoCobertura Cobertura { get; }

        public CriarCotacaoCommand(
            string marcaVeiculo,
            string modeloVeiculo,
            int anoVeiculo,

            string cpfProprietario,
            string nomeProprietario,
            Endereco enderecoProprietario,
            DateTime dataNascimentoProprietario,

            string cpfCondutor,
            string nomeCondutor,
            Endereco enderecoCondutor,
            DateTime dataNascimentoCondutor,
            TipoCobertura coberturasSelecionada)
        {
            MarcaVeiculo = marcaVeiculo;
            ModeloVeiculo = modeloVeiculo;
            AnoVeiculo = anoVeiculo;

            CpfProprietario = cpfProprietario;
            NomeProprietario = nomeProprietario;
            EnderecoProprietario = enderecoProprietario;
            DataNascimentoProprietario = dataNascimentoProprietario;

            CpfCondutor = cpfCondutor;
            NomeCondutor = nomeCondutor;
            EnderecoCondutor = enderecoCondutor;
            DataNascimentoCondutor = dataNascimentoCondutor;
            Cobertura = coberturasSelecionada;
        }
    }
}
