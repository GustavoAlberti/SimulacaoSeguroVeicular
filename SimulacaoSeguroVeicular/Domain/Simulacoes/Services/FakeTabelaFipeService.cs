namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Services
{
    public class FakeTabelaFipeService
    {
        private const decimal VALOR_BASE = 50000m;

        public Task<decimal> ConsultarValorAsync(string marca, string modelo, int ano)
        {
            // Simula o valor da Tabela Fipe
            //Valor base do veiculo 50.000.
            //Subtrai o ano corrente com o ano do veiculo
            //multiplica por 1000 a idade do veiculo.
            //apenas para teste.
            decimal valorFipe = VALOR_BASE + (DateTime.Now.Year - ano) * 1000;
            return Task.FromResult(valorFipe);
        }
    }
}
