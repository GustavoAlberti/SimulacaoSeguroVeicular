using SimulacaoSeguroVeicular.Dominio.Simulacoes;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Services
{
    public class ValorSeguroService
    {

        public decimal CalcularValorSeguroAsync(CotacaoSeguroVeicular cotacao)
        {
            decimal valorFipe = cotacao.ValorMercadoFipe ?? 0;
            int nivelRisco = cotacao.NivelDeRisco ?? 1;
            decimal ajustePercentual;
            decimal valorBase;

            //Coberturas Básicas e Custo Base
            //Cada cobertura tem um custo base que é aplicado sobre o valor de mercado do veículo
            //Cobertura            | Custo Base(%) sobre o Valor de Mercado (Tabela Fipe)
            //Roubo/Furto          | 3 %
            //Colisão              | 4 %
            //Terceiros            | 1.5 %
            //Proteção Residencial | Taxa fixa de R$ 100
            switch (cotacao.CoberturaSelecionada)
            {
                case TipoCobertura.RouboFurto:
                    valorBase = valorFipe * 0.03m;
                    break;
                case TipoCobertura.Colisao:
                    valorBase = valorFipe * 0.04m;
                    break;
                case TipoCobertura.Terceiros:
                    valorBase = valorFipe * 0.015m;
                    break;
                case TipoCobertura.ProtecaoResidencial:
                    valorBase = 100m;
                    break;
                default:
                    valorBase = 0m;
                    break;
            }

            //Ajuste pelo Nível de Risco (Custo da cobertura)
            //O custo das coberturas é ajustado com base no nível de risco do condutor:

            //Nível de Risco 1: sem ajuste(100 % do custo base)
            //Nível de Risco 2: +5 % sobre o custo base
            //Nível de Risco 3: +10 % sobre o custo base
            //Nível de Risco 4: +20 % sobre o custo base
            //Nível de Risco 5: +30 % sobre o custo base
            // Aplicar ajuste percentual com base no nível de risco
            switch (nivelRisco)
            {
                case 1:
                    ajustePercentual = 1.00m; 
                    break;
                case 2:
                    ajustePercentual = 1.05m; 
                    break;
                case 3:
                    ajustePercentual = 1.10m; 
                    break;
                case 4:
                    ajustePercentual = 1.20m;
                    break;
                case 5:
                    ajustePercentual = 1.30m; 
                    break;
                default:
                    ajustePercentual = 1.00m;
                    break;
            }

            return valorBase * ajustePercentual;

        }
    }
}
