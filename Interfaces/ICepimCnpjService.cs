using APIDeps.Dtos;
using APIDeps.Models;

namespace APIDeps.Interfaces
{
    public interface ICepimCnpjService
    {
        Task<ResponseGenerico<List<CepimCnpjResponse>>> CepimConsultaPorCNPJ(string cnpj);
    }
}
