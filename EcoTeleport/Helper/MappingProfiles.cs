using AutoMapper;
using EcoTeleport.Dto;
using EcoTeleport.Model;

namespace EcoTeleport.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
        }
    }
}
