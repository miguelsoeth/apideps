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
        }
    }
}
