using APIDeps.Interfaces;
using APIDeps.Validations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace APIDeps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class PepCpfController : ControllerBase
    {
        public readonly IPepCpfService _pepCpfService;

        public PepCpfController(IPepCpfService pepCpfService)
        {
            _pepCpfService = pepCpfService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> PepConsultaPorCPF([FromQuery][Required][RegularExpression("^[0-9]*$")] string cpf, [FromQuery][RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$")] string periodoInicial, [FromQuery][RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$")] string periodoFinal)
        {
            if (ValidadorCpf.IsValid(cpf))
            {
                var response = await _pepCpfService.PepConsultaPorCPF(cpf, periodoInicial, periodoFinal);
                if (response.CodigoHttp == HttpStatusCode.OK)
                {
                    return Ok(response.DadosRetorno);
                }
                else
                {
                    return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
                }
            }
            else
            {
                return BadRequest("CPF inválido");
            }
            
        }
    }
}
