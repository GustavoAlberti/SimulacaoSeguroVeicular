namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Application.InputModel
{
    public record CriarSimulacaoInputModel(
            string MarcaVeiculo,
            string ModeloVeiculo,
            int AnoVeiculo,

            string CpfPropietario,
            string NomeProprietario,
            DateTime DataNascimentoProprietario,
            EnderecoInputModel EnderecoProprietario,

            string CpfCondutor,
            string NomeCondutor,
            DateTime DataNascimentoCondutor,
            EnderecoInputModel EnderecoCondutor,

            CoberturaInputModel Cobertura

        );

    public record EnderecoInputModel(
        string Cep,
        string Rua,
        string Bairro,
        string Cidade,
        string Estado
    );

    public record CoberturaInputModel(string Tipo);
}
