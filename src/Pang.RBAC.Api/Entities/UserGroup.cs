using System;
namespace Pang.RBAC.Api.Entities
{
    public class UserGroup: Entity
    {
        public string Name{get; set;}
        public Guid ParentId{get; set;}
    }
}