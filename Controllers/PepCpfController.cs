using APIDeps.Interfaces;
using APIDeps.Validations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace APIDeps.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> PepConsultaPorCPF([FromRoute][RegularExpression("^[0-9]*$")] string cpf)
        {
            if (ValidadorCpf.IsValid(cpf))
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
            else
            {
                return BadRequest("CPF inválido");
            }
            
        }
    }
}
