using APIDeps.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIDeps.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PepCpfController : ControllerBase
    {
        public readonly IPepCpfService _pepCpfService;

        public PepCpfController(IPepCpfService pepCpfService)
        {
            _pepCpfService = pepCpfService;
        }

        [HttpGet("consulta/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> PepConsultaPorCPF([FromRoute] string cpf)
        {
            var response = await _pepCpfService.PepConsultaPorCPF(cpf);
            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }
    }
}
