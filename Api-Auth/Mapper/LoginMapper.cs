using Api_Auth.Dtos;
using Api_Auth.Models;
using static Utils.Helper;
using AutoMapper;

namespace Api_Auth.Mapper
{
    public class LoginMapper : Profile
    {
        public LoginMapper()
        {
            CreateMap<RegisterDto, RegisterModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PassCrypt, opt => opt.MapFrom(src => GenerateHash(src.Password)))
                .ForMember(dest => dest.DateRegister, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
