using AutoMapper;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;

namespace Pang.RBAC.Api.Profiles
{
    public class ProfileBase : Profile
    {
        public ProfileBase()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<FileResource, FileResourceDto>();
            CreateMap<FileResourceDto, FileResource>();

            CreateMap<FunctionOperation, FunctionOperationDto>();
            CreateMap<FunctionOperationDto, FunctionOperation>();

            CreateMap<Menu, MenuDto>();
            CreateMap<MenuDto, Menu>();

            CreateMap<PageElement, PageElementDto>();
            CreateMap<PageElementDto, PageElement>();

            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionDto, Permission>();

            CreateMap<PermissionFileResourceAss, PermissionFileResourceAssDto>();
            CreateMap<PermissionFileResourceAssDto, PermissionFileResourceAss>();

            CreateMap<PermissionFunctionOperationAss, PermissionFunctionOperationAssDto>();
            CreateMap<PermissionFunctionOperationAssDto, PermissionFunctionOperationAss>();

            CreateMap<PermissionMenuAss, PermissionMenuAssDto>();
            CreateMap<PermissionMenuAssDto, PermissionMenuAss>();

            CreateMap<PermissionPageElementAss, PermissionPageElementAssDto>();
            CreateMap<PermissionPageElementAssDto, PermissionPageElementAss>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<RolePermissionAss, RolePermissionAssDto>();
            CreateMap<RolePermissionAssDto, RolePermissionAss>();

            CreateMap<RoleUserGroupAss, RoleUserGroupAssDto>();
            CreateMap<RoleUserGroupAssDto, RoleUserGroupAss>();

            CreateMap<UserGroup, UserGroupDto>();
            CreateMap<UserGroupDto, UserGroup>();

            CreateMap<UserRoleAss, UserRoleAssDto>();
            CreateMap<UserRoleAssDto, UserRoleAss>();

            CreateMap<UserUserGroupAss, UserUserGroupAssDto>();
            CreateMap<UserUserGroupAssDto, UserUserGroupAss>();
        }
    }
}