using SimulacaoSeguroVeicular.Dominio.Simulacoes;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Services
{
    public class CalculaPontuacaoNivelRiscoService
    {
        public Task<int> CalcularNivelRiscoAsync(CotacaoSeguroVeicular cotacao)
        {
            // Cálculo da pontuação com base na idade do condutor
            int pontuacaoIdade = CalcularPontuacaoIdade(cotacao.Condutor.DataNascimento);

            // Cálculo da pontuação com base no número de acidentes
            int pontuacaoHistoricoAcidentes = CalcularPontuacaoHistoricoAcidentes(cotacao.NumeroDeAcidentes);

            // Cálculo da pontuação com base na localidade
            int pontuacaoLocalidade = CalcularPontuacaoLocalidade(cotacao.Condutor.Residencial.Cep);

            int pontuacaoTotal = pontuacaoIdade + pontuacaoHistoricoAcidentes + pontuacaoLocalidade;

            return Task.FromResult(pontuacaoTotal);
        }

        private static int CalcularPontuacaoLocalidade(string cep)
        {
            //Variavel de Localidade de Residência
            //Criterio Risco Associado à região
            //Baixo risco: 5 pontos
            //Médio risco: 10 pontos
            //Alto risco: 20 pontos
            return 10;
        }

        private static int CalcularPontuacaoHistoricoAcidentes(int? numeroDeAcidentes)
        {
            //Variavel de Histórico de Acidentes
            //Criterio: Quantidade de acidentes nos últimos 3 anos
            //Nenhum acidente: 0 pontos
            //1 acidente: 10 pontos
            //2 acidentes: 20 pontos
            //3 ou mais acidentes: 30 pontos
            switch (numeroDeAcidentes)
            {
                case 0:
                    return 0;
                case 1:
                    return 10;
                case 2:
                    return 20;
                case >= 3:
                    return 30;
                default:
                    return 0;
            }
        }

        private static int CalcularPontuacaoIdade(DateTime dataNascimento)
        {
            //Variavel idade do condutor
            //Criterio: Condutores mais jovens ou idosos têm maior risco
            //18-25 anos: 15 pontos
            //26 - 40 anos: 5 pontos
            //41 - 60 anos: 3 pontos
            //Acima de 60 anos: 10 pontos

            int idade = DateTime.Now.Year - dataNascimento.Year;

            switch (idade)
            {
                case >= 18 and <= 25:
                    return 15;
                case >= 26 and <= 40:
                    return 5;
                case >= 41 and <= 60:
                    return 3;
                case > 60:
                    return 10;
                default:
                    return 0;
            }
        }
    }
}
