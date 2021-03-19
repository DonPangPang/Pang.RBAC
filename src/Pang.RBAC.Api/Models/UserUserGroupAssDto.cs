using System;

namespace Pang.RBAC.Api.Models
{
    public class UserUserGroupAssDto : BaseDto
    {
        public Guid UserId{get; set;}
        public Guid UserGroupId{get; set;}
    }
}