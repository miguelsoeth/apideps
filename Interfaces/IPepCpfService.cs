using APIDeps.Dtos;
using APIDeps.Models;

namespace APIDeps.Interfaces
{
    public interface IPepCpfService
    {
        Task<ResponseGenerico<List<PepCpfResponse>>> PepConsultaPorCPF(string cpf, string periodoInicial, string periodoFinal); 
    }
}
