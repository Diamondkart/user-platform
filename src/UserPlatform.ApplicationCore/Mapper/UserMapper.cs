using AutoMapper;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.Domain.Entities;

namespace UserPlatform.ApplicationCore.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, UserDetails>();
            CreateMap<UserDetails, CreateUserResponse>();
        }
    }
}