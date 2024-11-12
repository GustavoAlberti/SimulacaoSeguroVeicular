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

        [HttpPost("Simular")]
        public async Task<IActionResult> CriarCotacao(
            [FromBody] CriarSimulacaoInputModel input,
            [FromServices] CriarCotacaoHandler handler,
            CancellationToken cancellationToken)
        {

            var command = CriarCotacaoCommand.Criar(input);
            if (command.IsFailure)
                return BadRequest(command.Error);

            var result = await handler.CriarCotacao(command.Value, cancellationToken);

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }

    }
}
