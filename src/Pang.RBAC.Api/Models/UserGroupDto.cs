using System;

namespace Pang.RBAC.Api.Models
{
    public class UserGroupDto : BaseDto
    {
        public string Name{get; set;}
        public Guid ParentId{get; set;}
    }
}