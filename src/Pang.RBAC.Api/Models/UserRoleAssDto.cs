using System;

namespace Pang.RBAC.Api.Models
{
    public class UserRoleAssDto : BaseDto
    {
        public Guid UserId{get; set;}
        public Guid RoleId{get; set;}
    }
}