using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Models;

namespace BancaApi.Profiles
{
    public class BancaProfile: Profile
    {
        public BancaProfile()
        {
            CreateMap<Banca, BancaDto>().ReverseMap();
        }
    }
}
