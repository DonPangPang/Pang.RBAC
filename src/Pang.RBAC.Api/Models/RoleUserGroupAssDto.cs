using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// 角色和用户组之间的关联
    /// </summary>
    public class RoleUserGroupAssDto : BaseDto
    {
        /// <summary>
        /// 用户组Id
        /// </summary>
        public Guid UserGroupId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public Guid RoleId { get; set; }
    }
}