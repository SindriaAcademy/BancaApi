using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Models;

namespace BancaApi.Profiles
{
    public class ContoProfile: Profile
    {
        public ContoProfile()
        {
            CreateMap<Conto, ContoDto>().ReverseMap();
            
        }
    }
}
