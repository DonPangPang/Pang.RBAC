using System;

namespace Pang.RBAC.Api.Models
{
    public class RoleUserGroupAssDto : BaseDto
    {
        public Guid UserGroupId{get; set;}
        public Guid RoleId{get; set;}
    }
}