using Microsoft.AspNetCore.Mvc;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Handlers;

namespace SimulacaoSeguroVeicular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AprovacaoController : ControllerBase
    {
        
        [HttpPost("{cotacaoId}/aprovar")]
        public async Task<IActionResult> AprovarCotacao(
            int cotacaoId,
            [FromServices] AprovarCotacaoHandler aprovarCotacaoHandler,
            CancellationToken cancellationToken)
        {
            var result = await aprovarCotacaoHandler.AprovarCotacao(cotacaoId, cancellationToken);

            if (result.IsSuccess)
                return Ok("Cotação aprovada e workflow retomado.");

            return BadRequest("Falha ao aprovar a cotação.");
        }
    }
}
