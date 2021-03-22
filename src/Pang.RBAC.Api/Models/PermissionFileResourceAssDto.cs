using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 权限和文件资源的关联
    /// </summary>
    public class PermissionFileResourceAssDto : BaseDto
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        public Guid PermissionId { get; set; }

        /// <summary>
        /// 文件Id
        /// </summary>
        public Guid FileResourceId { get; set; }
    }
}