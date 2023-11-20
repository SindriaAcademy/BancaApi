using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Models;

namespace BancaApi.Profiles
{
    public class ContoProfile: Profile
    {
        public ContoProfile()
        {
            CreateMap<ContoEntity, ContoDto>().ReverseMap();
            
        }
    }
}
