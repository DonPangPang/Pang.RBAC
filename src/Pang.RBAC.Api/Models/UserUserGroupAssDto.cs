using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// �û����û���֮��Ĺ���
    /// </summary>
    public class UserUserGroupAssDto : BaseDto
    {
        /// <summary>
        /// �û�Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// �û���Id
        /// </summary>
        public Guid UserGroupId { get; set; }
    }
}