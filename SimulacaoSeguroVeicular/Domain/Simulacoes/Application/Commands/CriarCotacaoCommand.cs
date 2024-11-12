using CSharpFunctionalExtensions;
using FluentValidation;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Application.InputModel;
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

        public static Result<CriarCotacaoCommand> Criar(CriarSimulacaoInputModel input)
        {

            var command = new CriarCotacaoCommand(
                input.MarcaVeiculo,
                input.ModeloVeiculo,
                input.AnoVeiculo,
                input.CpfProprietario,
                input.NomeProprietario,
                new Endereco(input.EnderecoProprietario.Cep, input.EnderecoProprietario.Rua,
                             input.EnderecoProprietario.Bairro, input.EnderecoProprietario.Cidade,
                             input.EnderecoProprietario.Estado),
                input.DataNascimentoProprietario,
                input.CpfCondutor,
                input.NomeCondutor,
                new Endereco(input.EnderecoCondutor.Cep, input.EnderecoCondutor.Rua,
                             input.EnderecoCondutor.Bairro, input.EnderecoCondutor.Cidade,
                             input.EnderecoCondutor.Estado),
                input.DataNascimentoCondutor,
                Enum.Parse<TipoCobertura>(input.Cobertura.Tipo, true)
            );

            var result = new CriarCotacaoCommandValidator().Validate(command);
            if (result.IsValid)
                return command;

            var errors = result.Errors.Select(validationFailure => validationFailure.ErrorMessage);
            return Result.Failure<CriarCotacaoCommand>(string.Join(" - ", errors));
        }

        public class CriarCotacaoCommandValidator : AbstractValidator<CriarCotacaoCommand>
        {
            public CriarCotacaoCommandValidator()
            {
                ClassLevelCascadeMode = CascadeMode.Continue;

                RuleFor(c => c.MarcaVeiculo)
                    .NotEmpty().WithMessage("A marca do veículo é obrigatória.");

                RuleFor(c => c.ModeloVeiculo)
                    .NotEmpty().WithMessage("O modelo do veículo é obrigatório.");

                RuleFor(c => c.AnoVeiculo)
                    .GreaterThan(1885).WithMessage("O ano do veículo deve ser maior que 1885.");

                RuleFor(c => c.CpfProprietario)
                    .NotEmpty().WithMessage("O CPF do proprietário é obrigatório.");

                RuleFor(c => c.NomeProprietario)
                    .NotEmpty().WithMessage("O nome do proprietário é obrigatório.");

                RuleFor(c => c.EnderecoProprietario)
                    .NotNull().WithMessage("O endereço do proprietário é obrigatório.");

                RuleFor(c => c.DataNascimentoProprietario)
                    .LessThan(DateTime.Now).WithMessage("A data de nascimento do proprietário deve ser no passado.");

                RuleFor(c => c.CpfCondutor)
                    .NotEmpty().WithMessage("O CPF do condutor é obrigatório.");

                RuleFor(c => c.NomeCondutor)
                    .NotEmpty().WithMessage("O nome do condutor é obrigatório.");

                RuleFor(c => c.EnderecoCondutor)
                    .NotNull().WithMessage("O endereço do condutor é obrigatório.");

                RuleFor(c => c.DataNascimentoCondutor)
                    .LessThan(DateTime.Now).WithMessage("A data de nascimento do condutor deve ser no passado.");

                RuleFor(c => c.Cobertura)
                    .IsInEnum().WithMessage("O tipo de cobertura selecionada é inválido.");
            }
        }
    }
}
