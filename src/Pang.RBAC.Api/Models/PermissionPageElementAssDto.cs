using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 权限和页面元素之间的关联
    /// </summary>
    public class PermissionPageElementAssDto : BaseDto
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        public Guid PermissionId { get; set; }

        /// <summary>
        /// 页面元素Id
        /// </summary>
        public Guid PageElementId { get; set; }
    }
}