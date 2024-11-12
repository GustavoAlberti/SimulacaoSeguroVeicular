using Microsoft.AspNetCore.Mvc;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Handlers;

namespace SimulacaoSeguroVeicular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReprovacaoController : ControllerBase
    {
        
        [HttpPost("{cotacaoId}/reprovar")]
        public async Task<IActionResult> AprovarCotacao(
            int cotacaoId,
            [FromServices] ReprovarCotacaoHandler reprovarCotacaoHandler,
            CancellationToken cancellationToken)
        {
            var result = await reprovarCotacaoHandler.ReprovarCotacao(cotacaoId, cancellationToken);

            if (result.IsSuccess)
                return Ok("Cotação reprovada e workflow retomado.");

            return BadRequest("Falha ao reprovar a cotação.");
        }
    }
}
