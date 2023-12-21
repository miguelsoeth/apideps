using APIDeps.Interfaces;
using APIDeps.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace APIDeps.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CepimCnpjController : ControllerBase
    {
        public readonly ICepimCnpjService _cepimCnpjService;

        public CepimCnpjController(ICepimCnpjService cepimCnpjService)
        {
            _cepimCnpjService = cepimCnpjService;
        }

        [HttpGet("consulta/{cnpj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<ActionResult> CepimConsultaPorCNPJ([FromRoute][RegularExpression("^[0-9]*$")] string cnpj)
        {
            if (ValidadorCnpj.IsValid(cnpj))
            {
                var response = await _cepimCnpjService.CepimConsultaPorCNPJ(cnpj);
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
                return BadRequest("CNPJ inválido");
            }            
        }
    }
}
