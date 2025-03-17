using AutoMapper;
using OpenBazaar.Model.Users.Dtos;
using OpenBazaar.Model.Users.Entities;

namespace OpenBazaar.Service.Users.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UpdateUserRequest, User>();
        CreateMap<UserDto, User>().ReverseMap();
    }
}