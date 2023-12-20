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

        public async Task<ResponseGenerico<PepCpfResponse>> PepConsultaPorCPF(string cpf)
        {
            var pep = await _portalTransparenciaAPI.PepConsultaPorCPF(cpf);
            return _mapper.Map<ResponseGenerico<PepCpfResponse>>(pep);
        }
    }
}
