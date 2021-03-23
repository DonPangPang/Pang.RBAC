using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 角色和权限之间的关联
    /// </summary>
    public class RolePermissionAssDto : BaseDto
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 权限Id
        /// </summary>
        public Guid PermissionId { get; set; }
    }
}