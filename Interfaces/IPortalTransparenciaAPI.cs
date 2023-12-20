
using APIDeps.Dtos;
using APIDeps.Models;

namespace APIDeps.Interfaces
{
    public interface IPortalTransparenciaAPI
    {
        Task<ResponseGenerico<PepCpfModel>> PepConsultaPorCPF(string cep);
    }
}
