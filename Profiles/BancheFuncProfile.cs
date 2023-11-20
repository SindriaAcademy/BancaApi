using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Entities;

namespace BancaApi.Profiles
{
    public class BancheFuncProfile: Profile
    {
        public BancheFuncProfile()
        {
            CreateMap<BancheFunzionalitaEntity, BancheFuncDto>().ReverseMap();
        }
    }
}
