using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// ��ɫ���û���֮��Ĺ���
    /// </summary>
    public class RoleUserGroupAssDto : BaseDto
    {
        /// <summary>
        /// �û���Id
        /// </summary>
        public Guid UserGroupId { get; set; }

        /// <summary>
        /// ��ɫId
        /// </summary>
        public Guid RoleId { get; set; }
    }
}