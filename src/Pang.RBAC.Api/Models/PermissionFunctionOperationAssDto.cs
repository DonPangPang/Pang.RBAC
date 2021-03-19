using System;

namespace Pang.RBAC.Api.Models
{
    public class PermissionFunctionOperationAssDto : BaseDto
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        /// <value></value>
        public Guid PermissionId{get; set;}
        /// <summary>
        /// 功能操作Id
        /// </summary>
        /// <value></value>
        public Guid FunctionOperationId{get; set;}
    }
}