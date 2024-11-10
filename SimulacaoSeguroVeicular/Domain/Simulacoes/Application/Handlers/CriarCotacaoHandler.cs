using CSharpFunctionalExtensions;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Commands;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao;
using SimulacaoSeguroVeicular.Dominio.Simulacoes;
using SimulacaoSeguroVeicular.Infrastructure.Data;
using WorkflowCore.Interface;
using WorkflowCore.Services;

namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Handlers
{
    public class CriarCotacaoHandler(
        CotacaoRepositorio cotacaoRepositorio,
        UnitOfWork unitOfWork,
        IWorkflowHost workflowHost)
    {
        public async Task<Result<int>> CriarCotacao(CriarCotacaoCommand command, CancellationToken cancellationToken)
        {
            var veiculo = new Veiculo(command.MarcaVeiculo, command.ModeloVeiculo, command.AnoVeiculo);
            var proprietario = new Pessoa(command.CpfProprietario, command.NomeProprietario, command.DataNascimentoProprietario, command.EnderecoProprietario);
            var condutor = new Pessoa(command.CpfCondutor,command.NomeCondutor,command.DataNascimentoCondutor,command.EnderecoCondutor);

            // Criação da simulação
            var cotacao = CotacaoSeguroVeicular.Criar(
                veiculo,
                proprietario,
                condutor,
                command.Cobertura);

            if (cotacao.IsFailure)
                return Result.Failure<int>(cotacao.Error);

            await cotacaoRepositorio.Adicionar(cotacao.Value, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            // Inicia o workflow de análise da simulacao

            await workflowHost.StartWorkflow(
                "CotacaoWorkflow",
                new CotacaoWorkflowData
                {
                    CotacaoId = cotacao.Value.Id
                });

            return Result.Success(cotacao.Value.Id);

        }

        #region enunciado
        //Primeiro cria a cotacao na base retorna e fazemos o workflow.


        // INFORMACOES COMPLEMENTARES

        //Deve consultar e complementar a simulação com informações adicionais, incluindo:

        //Tabela Fipe: verificar o valor de mercado do veículo com base em uma API simulada -- service
        //Historico acidentes: consultar um histórico de acidentes do condutor com base em uma API simulada -- service

        //Nível de Risco: calcular um índice de risco com base na idade do condutor, histórico de direção e localidade. 1 step workflow

        //Deve consultar as e complementar a simulação com informações adicionais, incluindo:


        //Calculo do nível de risco.
        //O nível de risco é determinado com base em variáveis comuns em avaliações de seguros veiculares, como idade do condutor, histórico de direção e localidade de residência.
        //Cada variável tem uma pontuação que aumenta ou reduz o nível de risco.

        //Variaveis e pontuacoes:

        //Variavel idade do condutor
        //Criterio: Condutores mais jovens ou idosos têm maior risco
        //18-25 anos: 15 pontos
        //26 - 40 anos: 5 pontos
        //41 - 60 anos: 3 pontos
        //Acima de 60 anos: 10 pontos

        //montar uma strategy talvez passando a idade do condutor ou apenas usar o método da classe Cobertura para calucular a pontuacao.
        //var pontuacaoIdadeCondutor = condutor.Idade; //PASSANDO A IDADE DO CONDUTOR

        //Variavel de Histórico de Acidentes
        //Criterio: Quantidade de acidentes nos últimos 3 anos
        //Nenhum acidente: 0 pontos
        //1 acidente: 10 pontos
        //2 acidentes: 20 pontos
        //3 ou mais acidentes: 30 pontos
        // var pontuacaoHistoricoAcidentes = condutor.Cpf; //passando o CPF DO CONDUTOR

        //Variavel de Localidade de Residência
        //Criterio Risco Associado à região
        //Baixo risco: 5 pontos
        //Médio risco: 10 pontos
        //Alto risco: 20 pontos
        // var pontuacaoLocalidadeResidencial = condutor.Residencial.Cep; //PASSANDO O CEP DO CONDUTOR

        //Classificação do Nível de Risco
        //Com base nas pontuacoes 
        //Pontuação Total |	Nível de Risco
        //0 - 10 pontos   |1(Baixo)
        //11 - 25 pontos  |2
        //26 - 40 pontos  |3
        //41 - 55 pontos  |4
        //56 pontos oumais|5(Alto)

        //Classifica o nivel de risco de 1 a 5 com base nessas informaçõs. 
        //var classificacaoNivelRisco = pontuacaoIdadeCondutor + pontuacaoHistoricoAcidentes + pontuacaoLocalidadeResidencial;


        //FIM INFORMACOES COMPLEMENTARES.

        //Calculo do valor do Seguro. 2 step workflow provavelmente

        //O cálculo do seguro deve ser feito com base nas informações complementares e nas coberturas escolhidas. 
        // A aplicação deve considerar:
        // 1 - Valor de Mercado (Tabela Fipe): o valor do veículo serve como base para algumas coberturas. 
        // 2 - Nível de Risco: o nível de risco influencia diretamente o custo das coberturas, aplicando um ajuste percentual sobre o custo base.

        //Coberturas Básicas e Custo Base
        //Cada cobertura tem um custo base que é aplicado sobre o valor de mercado do veículo

        //Cobertura            | Custo Base(%) sobre o Valor de Mercado (Tabela Fipe)
        //Roubo/Furto          | 3 %
        //Colisão              | 4 %
        //Terceiros            | 1.5 %
        //Proteção Residencial | Taxa fixa de R$ 100


        //Ajuste pelo Nível de Risco (Custo da cobertura)
        //O custo das coberturas é ajustado com base no nível de risco do condutor:

        //Nível de Risco 1: sem ajuste(100 % do custo base)
        //Nível de Risco 2: +5 % sobre o custo base
        //Nível de Risco 3: +10 % sobre o custo base
        //Nível de Risco 4: +20 % sobre o custo base
        //Nível de Risco 5: +30 % sobre o custo base

        //Define o ValorSeguroTotal.

        //Aprovação do Seguro - 3 step
        //Após o cálculo, o sistema aguarda uma aprovação do usuário para a cotacao (deve ser gerada como pendente).
        //Que pode ser aprovada ou rejeitada via uma requisição HTTP.


        //Emissao Apólice
        //Uma vez aprovada a simulação, o sistema deve emitir uma apólice fictícia com todas as informações relevantes sobre as coberturas, valor total, vigência, entre outros.
        #endregion
    }
}

