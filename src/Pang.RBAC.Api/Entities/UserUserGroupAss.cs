using System;
namespace Pang.RBAC.Api.Entities
{
    public class UserUserGroupAss: Entity
    {
        public Guid UserId{get; set;}
        public Guid UserGroupId{get; set;}

        public User User{get; set;}
        public UserGroup UserGroup{get; set;}
    }
}