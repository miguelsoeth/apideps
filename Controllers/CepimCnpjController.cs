using APIDeps.Interfaces;
using APIDeps.Validations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;

namespace APIDeps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class CepimCnpjController : ControllerBase
    {
        public readonly ICepimCnpjService _cepimCnpjService;

        public CepimCnpjController(ICepimCnpjService cepimCnpjService)
        {
            _cepimCnpjService = cepimCnpjService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<ActionResult> CepimConsultaPorCNPJ([FromQuery][Required][RegularExpression("^[0-9]*$")] string cnpj, [FromQuery][RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$")] string periodoInicial, [FromQuery][RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$")] string periodoFinal)
        {
            if (ValidadorCnpj.IsValid(cnpj))
            {
                var response = await _cepimCnpjService.CepimConsultaPorCNPJ(cnpj);
                if (response.CodigoHttp == HttpStatusCode.OK)
                {
                    if (DateOnly.TryParseExact(periodoInicial, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly dataInicial) && DateOnly.TryParseExact(periodoFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly dataFinal))
                    {
                        Console.WriteLine(dataFinal.ToString() +" | "+ dataInicial.ToString());
                        var filteredResponse = response.DadosRetorno.Where(item =>
                        DateOnly.TryParseExact(item.DataReferencia, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly refDate)
                        && refDate <= dataFinal
                        && refDate >= dataInicial)
                        .ToList();

                        return Ok(filteredResponse);
                    }
                    else
                    {
                        Console.WriteLine("Failed to convert periods");
                        return BadRequest("Invalid date format");
                    }
                    
                                   
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
