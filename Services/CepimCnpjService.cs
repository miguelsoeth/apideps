using APIDeps.Dtos;
using APIDeps.Interfaces;
using APIDeps.Models;
using AutoMapper;

namespace APIDeps.Services
{
    public class CepimCnpjService : ICepimCnpjService
    {
        private readonly IMapper _mapper;
        private readonly IPortalTransparenciaAPI _portalTransparenciaAPI;

        public CepimCnpjService(IMapper mapper, IPortalTransparenciaAPI portalTransparenciaAPI)
        {
            _mapper = mapper;
            _portalTransparenciaAPI = portalTransparenciaAPI;
        }

        public async Task<ResponseGenerico<List<CepimCnpjResponse>>> CepimConsultaPorCNPJ(string cnpj)
        {
            var cepim = await _portalTransparenciaAPI.CepimConsultaPorCNPJ(cnpj);
            return _mapper.Map<ResponseGenerico<List<CepimCnpjResponse>>>(cepim);
        }
    }
}
