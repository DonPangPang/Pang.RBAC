using System;

namespace Pang.RBAC.Api.Models
{
    public class PermissionFileResourceAssDto : BaseDto
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        /// <value></value>
        public Guid PermissionId{get; set;}
        /// <summary>
        /// 文件Id
        /// </summary>
        /// <value></value>
        public Guid FileResourceId{get; set;}
    }
}