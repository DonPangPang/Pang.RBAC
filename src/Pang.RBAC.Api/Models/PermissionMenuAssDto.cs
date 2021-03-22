using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 权限和菜单之间的关联
    /// </summary>
    public class PermissionMenuAssDto : BaseDto
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        public Guid PermissionId { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        public Guid MenuId { get; set; }
    }
}