using System;

namespace Pang.RBAC.Api.Models
{
    /// <summary>
    /// �û��ͽ�ɫ֮��Ĺ���
    /// </summary>
    public class UserRoleAssDto : BaseDto
    {
        /// <summary>
        /// �û�Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// ��ɫId
        /// </summary>
        public Guid RoleId { get; set; }
    }
}