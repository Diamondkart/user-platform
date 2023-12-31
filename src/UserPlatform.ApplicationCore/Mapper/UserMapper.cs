﻿using AutoMapper;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.Domain.Entities;

namespace UserPlatform.ApplicationCore.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, UserDetails>()
                .ForPath(dest => dest.Password, opt => opt.MapFrom(src => src.SecurePassword));
            CreateMap<UserDetails, CreateUserResponse>();
            CreateMap<GetUsersRequest, UserDetails>();
            CreateMap<UserDetails, GetUsersResponse>();
            CreateMap<GetByUserIdRequest, UserDetails>();
            CreateMap<UserDetails, GetByUserIdResponse>();
            CreateMap<GetByUserNameRequest, UserDetails>();
            CreateMap<UserDetails, GetByUserNameResponse>();
            CreateMap<UpdateUserRequest, UserDetails>();
            CreateMap<UserDetails, UpdateUserResponse>();
            CreateMap<UpdatePhoneNumberRequest, UserDetails>()
                .ForPath(dest => dest.MobileNo, opt => opt.MapFrom(src => src.PhoneNumber));
            CreateMap<UpdateNameRequest, UserDetails>();
            CreateMap<ChangePassword, ChangePasswordResponse>();
            CreateMap<GeneratePasswordRequest, UserDetails>();
            CreateMap<GeneratePasswordRequest, ChangePassword>();
            CreateMap<VerifyUserCredRequest, UserDetails>();
        }
    }
}