using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Models;

namespace BancaApi.Profiles
{
    public class UtenteProfile : Profile
    {
        public UtenteProfile()
        {
            CreateMap<Utente, UtenteDto>().ReverseMap();
        }
    }
}
