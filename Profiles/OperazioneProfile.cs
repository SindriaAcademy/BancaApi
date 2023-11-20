using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Models;

namespace BancaApi.Profiles
{
    public class OperazioneProfile: Profile
    {
        public OperazioneProfile()
        {
            CreateMap<OperazioneEntity, OperazioneDto>().ReverseMap();
        }
    }
}
