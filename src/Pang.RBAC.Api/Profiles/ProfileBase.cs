using AutoMapper;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;

namespace Pang.RBAC.Api.Profiles
{
    public class ProfileBase: Profile
    {
        public ProfileBase(){
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}