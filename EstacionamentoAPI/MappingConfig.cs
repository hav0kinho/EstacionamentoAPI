using AutoMapper;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Models.DTO;

namespace EstacionamentoAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Estacionamento, EstacionamentoDTO>().ReverseMap();
            CreateMap<Carro, CarroDTO>().ReverseMap();
        }
    }
}
