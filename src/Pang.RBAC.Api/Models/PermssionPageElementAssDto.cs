using System;

namespace Pang.RBAC.Api.Models
{
    public class PermssionPageElementAssDto : BaseDto
    {
        public Guid PermissionId{get; set;}
        public Guid PageElementId{get; set;}
    }
}