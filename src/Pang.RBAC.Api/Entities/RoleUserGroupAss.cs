using System;
namespace Pang.RBAC.Api.Entities
{
    public class RoleUserGroupAss: Entity
    {
        public Guid UserGroupId{get; set;}
        public Guid RoleId{get; set;}

        public UserGroup UserGroup{get; set;}
        public Role Role{get; set;}
    }
}