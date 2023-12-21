using APIDeps.Dtos;
using APIDeps.Models;
using AutoMapper;

namespace APIDeps.Mappings
{
    public class CepimCnpjMapping : Profile
    {
        public CepimCnpjMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));

            CreateMap<CepimCnpjResponse, CepimCnpjModel>();
            CreateMap<CepimCnpjModel, CepimCnpjResponse>();

            CreateMap<ConvenioModel, ConvenioResponse>();
            CreateMap<ConvenioResponse, ConvenioModel>();

            CreateMap<OrgaoMaximoModel, OrgaoMaximoResponse>();
            CreateMap<OrgaoMaximoResponse, OrgaoMaximoModel>();


            CreateMap<OrgaoSuperiorModel, OrgaoSuperiorResponse>();
            CreateMap<OrgaoSuperiorResponse, OrgaoSuperiorModel>();

            CreateMap<PessoaJuridicaModel, PessoaJuridicaResponse>();
            CreateMap<PessoaJuridicaResponse, PessoaJuridicaModel>();

        }
    }
}
