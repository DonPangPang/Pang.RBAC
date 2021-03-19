using System.Collections.Generic;
using System;

namespace Pang.RBAC.Api.Entities
{
    public class Role : Entity
    {
        public string Name{get; set;}

        public UserGroup UserGroup{get; set;}
        public ICollection<UserRoleAss> UserRoleAsses{get; set;}
        public ICollection<RolePermissionAss> RolePermissionAsses{get; set;}
    }
}