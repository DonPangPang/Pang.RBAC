using System.Collections.Generic;
using System;
namespace Pang.RBAC.Api.Entities
{
    public class UserGroup: Entity
    {
        public string Name{get; set;}
        public Guid ParentId{get; set;}

        public ICollection<UserUserGroupAss> UserUserGroupAsses{get; set;}
        public ICollection<RoleUserGroupAss> RoleUserGroupAsses{get; set;}
    }
}