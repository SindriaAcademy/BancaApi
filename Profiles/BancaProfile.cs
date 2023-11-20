using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Models;

namespace BancaApi.Profiles
{
    public class BancaProfile: Profile
    {
        public BancaProfile()
        {
            CreateMap<BancaEntity, BancaDto>().ReverseMap();
        }
    }
}
