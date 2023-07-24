using AutoMapper;
using ClienteService.DTOs;
using ClienteService.Models;


namespace ThomasGregApi.ClienteService.MapperProfiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<ClienteLogradouroResultDTO, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Logotipo, opt => opt.MapFrom(src => src.Logotipo))
                .ForMember(dest => dest.Logradouros, opt => opt.MapFrom(src => new List<Logradouro>
                    { new Logradouro
                    {
                        Id = src.LogradouroId,
                        Nome = src.LogradouroNome,
                        ClienteId = src.Id
                    }
                    }));
        }
    }
}

