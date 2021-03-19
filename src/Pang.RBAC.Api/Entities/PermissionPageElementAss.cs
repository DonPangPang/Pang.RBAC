using System;
namespace Pang.RBAC.Api.Entities
{
    public class PermissionPageElementAss: Entity
    {
        public Guid PermissionId{get; set;}
        public Guid PageElementId{get; set;}

        public Permission Permission{get; set;}
        public PageElement pageElement{get; set;}
    }
}