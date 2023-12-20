using APIDeps.Dtos;
using APIDeps.Models;

namespace APIDeps.Interfaces
{
    public interface IPepCpfService
    {
        Task<ResponseGenerico<PepCpfResponse>> PepConsultaPorCPF(string cpf);
    }
}
