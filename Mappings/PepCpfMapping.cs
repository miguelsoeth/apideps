using APIDeps.Dtos;
using APIDeps.Models;
using AutoMapper;

namespace APIDeps.Mappings
{
    public class PepCpfMapping : Profile
    {
        public PepCpfMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<PepCpfResponse, PepCpfModel>();
            CreateMap<PepCpfModel, PepCpfResponse>();
        }
    }
}
