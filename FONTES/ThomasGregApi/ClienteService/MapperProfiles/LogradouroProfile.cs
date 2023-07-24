using AutoMapper;
using ClienteService.DTOs;
using ClienteService.Models;
using System;


namespace ThomasGregApi.ClienteService.MapperProfiles
{
    public class LogradouroProfile : Profile
    {
        public LogradouroProfile()
        {
            CreateMap<LogradouroDTO, Logradouro>();

            CreateMap<Logradouro, LogradouroDTO>();
        }
    }
}
