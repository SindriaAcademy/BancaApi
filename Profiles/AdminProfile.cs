using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Entities;

namespace BancaApi.Profiles
{
    public class AdminProfile: Profile
    {
        public AdminProfile() 
        {
            CreateMap<AdminEntity, AdminDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdBanca, opt => opt.MapFrom(src => src.IdBanca))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ReverseMap();
        }
    }
}
