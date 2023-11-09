using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Models;

namespace BancaApi.Profiles
{
    public class OperazioneProfile: Profile
    {
        public OperazioneProfile()
        {
            CreateMap<Operazione, OperazioneDto>().ReverseMap();
        }
    }
}
