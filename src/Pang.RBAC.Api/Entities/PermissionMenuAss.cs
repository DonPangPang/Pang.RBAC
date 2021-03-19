using System.Collections.Generic;
using System;
namespace Pang.RBAC.Api.Entities
{
    /// <summary>
    /// 权限菜单关联表
    /// </summary>
    public class PermissionMenuAss: Entity
    {
        public Guid PermissionId{get; set;}
        public Guid MenuId{get; set;}

        public Permission Permission{get; set;}
        public Menu Menu{get; set;}
    }
}