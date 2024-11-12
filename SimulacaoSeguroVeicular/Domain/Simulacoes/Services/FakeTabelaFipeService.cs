namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Services
{
    public class FakeTabelaFipeService
    {
        private const decimal VALOR_BASE = 50000m;
        private const decimal VALOR_RESIDUAL = 10000m;

        public Task<decimal> ConsultarValorAsync(string marca, string modelo, int ano)
        {
            // Simula o valor da Tabela Fipe
            // Valor base do veiculo 50.000.
            // Subtrai o ano corrente com o ano do veiculo
            // Multiplica por 1000 a idade do veiculo, com fator de correção
            // Adiciona um valor residual para veículos muito antigos
            int idade = DateTime.Now.Year - ano;
            decimal fatorCorrecao = 1 / (1 + 0.1m * idade); // Fator de correção (ajustável)
            decimal desvalorizacao = idade * 1000 * fatorCorrecao;
            decimal valorFipe = Math.Max(VALOR_RESIDUAL, VALOR_BASE - desvalorizacao);
            return Task.FromResult(valorFipe);
        }
    }
    }
}
