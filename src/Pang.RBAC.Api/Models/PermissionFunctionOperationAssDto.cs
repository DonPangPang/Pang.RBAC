using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 权限和操作之间的关联
    /// </summary>
    public class PermissionFunctionOperationAssDto : BaseDto
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        public Guid PermissionId { get; set; }

        /// <summary>
        /// 功能操作Id
        /// </summary>
        public Guid FunctionOperationId { get; set; }
    }
}