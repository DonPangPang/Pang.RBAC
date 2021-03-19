using System;
namespace Pang.RBAC.Api.Entities
{
    public class RoleUserGroupAss: Entity
    {
        public Guid UserGroupId{get; set;}
        public Guid RoleId{get; set;}
    }
}