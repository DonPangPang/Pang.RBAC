using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 用户和用户组之间的关联
    /// </summary>
    public class UserUserGroupAssDto : BaseDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 用户组Id
        /// </summary>
        public Guid UserGroupId { get; set; }
    }
}