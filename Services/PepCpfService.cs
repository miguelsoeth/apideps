using APIDeps.Dtos;
using APIDeps.Interfaces;
using AutoMapper;

namespace APIDeps.Services
{
    public class PepCpfService : IPepCpfService
    {
        private readonly IMapper _mapper;
        private readonly IPortalTransparenciaAPI _portalTransparenciaAPI;

        public PepCpfService(IMapper mapper, IPortalTransparenciaAPI portalTransparenciaAPI)
        {
            _mapper = mapper;
            _portalTransparenciaAPI = portalTransparenciaAPI;
        }

        public async Task<ResponseGenerico<List<PepCpfResponse>>> PepConsultaPorCPF(string cpf, string periodoInicial, string periodoFinal)
        {
            var peps = await _portalTransparenciaAPI.PepConsultaPorCPF(cpf, periodoInicial, periodoFinal);
            return _mapper.Map<ResponseGenerico<List<PepCpfResponse>>>(peps);
        }
    }
}
