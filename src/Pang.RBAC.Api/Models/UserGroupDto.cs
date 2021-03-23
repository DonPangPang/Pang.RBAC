using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 用户组
    /// </summary>
    public class UserGroupDto : BaseDto
    {
        /// <summary>
        /// 用户组名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父用户组Id
        /// </summary>
        public Guid ParentId { get; set; }
    }
}