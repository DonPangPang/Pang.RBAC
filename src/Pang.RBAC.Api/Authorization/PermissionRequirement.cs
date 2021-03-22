using System;
using Microsoft.AspNetCore.Authorization;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Authorization
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Name{get; set;}
        public string Secret{get; set;}
        public string Issuer{get; set;}
        public string Audience{get; set;}
        public int AccessExpiration{get; set;}
        public int RefreshExpiration{get; set;}
    }
}