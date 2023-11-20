using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Models;

namespace BancaApi.Profiles
{
    public class UtenteProfile : Profile
    {
        public UtenteProfile()
        {
            CreateMap<UtenteEntity, UtenteDto>().ReverseMap();
        }
    }
}
