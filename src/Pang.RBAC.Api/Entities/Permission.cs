using System.Collections.Generic;

namespace Pang.RBAC.Api.Entities
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Permission : Entity
    {
        /// <summary>
        /// 权限类型/名称
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        public ICollection<RolePermissionAss> RolePermissionAsses { get; set; }
        public ICollection<PermissionFunctionOperationAss> PermissionFunctionOperationAsses { get; set; }
        public ICollection<PermissionMenuAss> PermissionMenuAsses { get; set; }
        public ICollection<PermissionPageElementAss> PermissionPageElementAsses { get; set; }
        public ICollection<PermissionFileResourceAss> permissionFileResourceAsses { get; set; }
    }
}