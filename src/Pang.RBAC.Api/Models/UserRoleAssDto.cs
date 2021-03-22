using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 用户和角色之间的关联
    /// </summary>
    public class UserRoleAssDto : BaseDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public Guid RoleId { get; set; }
    }
}