using System;

namespace Pang.RBAC.Api.Models
{
    public class RolePermissionAssDto : BaseDto
    {
        public Guid RoleId{get; set;}
        public Guid PermissionId{get; set;}
    }
}