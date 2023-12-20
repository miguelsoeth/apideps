using APIDeps.Dtos;
using APIDeps.Interfaces;
using APIDeps.Models;
using System.Dynamic;
using System.Text.Json;

namespace APIDeps.Rest
{
    public class PortalTransparenciaRest : IPortalTransparenciaAPI
    {
        private readonly string apiKey = "7c137febe8f79a03ffe7a437026f0e05";
        public async Task<ResponseGenerico<PepCpfModel>> PepConsultaPorCPF(string cpf)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.portaldatransparencia.gov.br/api-de-dados/peps?cpf={cpf}&descricaoFuncao=Deputado%20Federal&pagina=1");
            request.Headers.Add("accept", "*/*" );
            request.Headers.Add("chave-api-dados", apiKey);

            var response = new ResponseGenerico<PepCpfModel>();
            using ( var client = new HttpClient() )
            {
                var responsePortalTransparenciaApi = await client.SendAsync( request );
                var contentResponse = await responsePortalTransparenciaApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<PepCpfModel>( contentResponse );

                if (responsePortalTransparenciaApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responsePortalTransparenciaApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responsePortalTransparenciaApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>( contentResponse );
                }
            }
            return response;
        }
    }
}
