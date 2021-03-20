using System;
using Microsoft.AspNetCore.Authorization;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Authorization
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public  IServiceProvider ServiceProvider{get; set;}
        public PermissionRequirement(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}