using System;

namespace Pang.RBAC.Api.Models
{
    public class PermissionMenuAssDto : BaseDto
    {
        public Guid PermissionId{get; set;}
        public Guid MenuId{get; set;}
    }
}