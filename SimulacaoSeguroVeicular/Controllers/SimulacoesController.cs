using Microsoft.AspNetCore.Mvc;
using SimulacaoSeguroVeicular.Domain.Simulacoes;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Commands;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Handlers;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Application.InputModel;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Value_Objects;
using SimulacaoSeguroVeicular.Dominio.Simulacoes;

namespace SimulacaoSeguroVeicular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulacoesController : ControllerBase
    {

        [HttpPost("criar")]
        public async Task<IActionResult> CriarCotacao(
            [FromBody] CriarSimulacaoInputModel input,
            [FromServices] CriarCotacaoHandler handler,
            CancellationToken cancellationToken)
        {
            var command = new CriarCotacaoCommand(
                input.MarcaVeiculo,
                input.ModeloVeiculo,
                input.AnoVeiculo,

                input.CpfProprietario,
                input.NomeProprietario,
                new Endereco(
                    input.EnderecoProprietario.Cep,
                    input.EnderecoProprietario.Rua,
                    input.EnderecoProprietario.Bairro,
                    input.EnderecoProprietario.Cidade,
                    input.EnderecoProprietario.Estado),
                input.DataNascimentoProprietario,

                input.CpfCondutor,
                input.NomeCondutor,
                new Endereco(
                    input.EnderecoCondutor.Cep,
                    input.EnderecoCondutor.Rua,
                    input.EnderecoCondutor.Bairro,
                    input.EnderecoCondutor.Cidade,
                    input.EnderecoCondutor.Estado),
                input.DataNascimentoCondutor,

                Enum.Parse<TipoCobertura>(input.Cobertura.Tipo, true)
            );

            var result = await handler.CriarCotacao(command, cancellationToken);

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }

    }
}
